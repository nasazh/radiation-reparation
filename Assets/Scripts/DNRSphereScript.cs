using UnityEngine;

public class DNRSphereScript : MonoBehaviour {

    public string direction = "S";

    public Sprite violet;
    public Sprite red;
    public Sprite orange;
    public Sprite yellow;
    public Sprite salad;
    public Sprite green;
    public Sprite teal;
    public Sprite levander;
    public Sprite indigo;
    public Sprite blue;
    public Sprite sky;

    public GlobalState globalState;

    public int value;

    // Start is called before the first frame update
    void Start() {
        int color = Mathf.RoundToInt(Random.Range(0f, Constants.MAX_COLORS) * 10);
        Sprite selected = violet;
        switch (color) {
            case 1: selected = violet; break;
            case 2: selected = red; break;
            case 3: selected = orange; break;
            case 4: selected = yellow; break;
            case 5: selected = salad; break;
            case 6: selected = green; break;
            case 7: selected = teal; break;
            case 8: selected = levander; break;
            case 9: selected = indigo; break;
            case 10: selected = blue; break;
            case 11: selected = sky; break;
        }
        value = color;
        gameObject.GetComponentInChildren<SpriteRenderer>().sprite = selected;
        globalState = GameObject.Find("GlobalState").GetComponent<GlobalState>();
    }

    // Update is called once per frame
    void Update() {
        if ((direction == "S") && (transform.localPosition.y <= Constants.SCANNER_BELT_Y)) {
            transform.localPosition.Set(transform.localPosition.x, Constants.SCANNER_BELT_Y, transform.localPosition.z);
            direction = "E";
        }

        if (transform.localPosition.x >= Constants.OUTPUT_BELT_X) {
            transform.localPosition.Set(Constants.OUTPUT_BELT_X, transform.localPosition.y, transform.localPosition.z);
            direction = "N";
        }

        if (canMove()) {
            Move();
        }

    }

    private void Move() {
        float oldX = transform.localPosition.x;
        switch (direction) {
            case "S" :
                transform.Translate(Vector3.down * Time.deltaTime * Constants.BALLS_SPEED);
                break;
            case "E" :
                transform.Translate(Vector3.right * Time.deltaTime * Constants.BALLS_SPEED);
                break;
            case "N" :
                transform.Translate(Vector3.up * Time.deltaTime * Constants.BALLS_SPEED);
                break;
        }
        float newX = transform.localPosition.x;

        if ((oldX <= globalState.GetDestroyedX()) && (newX >= globalState.GetDestroyedX())) {
            globalState.destroyedDNRx = 2000f;
        }

    }

    private bool canMove() {
        bool leftOfDead = globalState.GetDestroyedX() > transform.localPosition.x;
        bool rightOfSpawn = globalState.addedDNRx <= transform.localPosition.x;

        return leftOfDead && (rightOfSpawn || !globalState.skipDNRSpawn);
    }

    public void onDeath() {
        if (globalState.destroyedDNRx == 2000f) {
            globalState.destroyedDNRx = gameObject.transform.localPosition.x;
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        DNRSphereScript dnrHitter = col.gameObject.GetComponent<DNRSphereScript>();
        RadiationBoltScript bolt = col.gameObject.GetComponent<RadiationBoltScript>();
        if (dnrHitter != null && dnrHitter.direction == "N") {
            globalState.skipDNRSpawn = true;
            globalState.pauseTime = true;
            dnrHitter.direction = "E";
            Vector3 spawnLocation = new Vector3(transform.localPosition.x - 62, transform.localPosition.y, transform.localPosition.z);
            dnrHitter.gameObject.transform.SetPositionAndRotation(spawnLocation, Quaternion.identity);
            globalState.addedDNRx = dnrHitter.gameObject.transform.localPosition.x - 0.01f;
        }
        if (bolt != null) {
            onDeath();
            Destroy(bolt.gameObject);
        }
    }

}
