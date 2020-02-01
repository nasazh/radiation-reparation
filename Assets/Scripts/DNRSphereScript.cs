using UnityEngine;

public class DNRSphereScript : MonoBehaviour {

    string direction = "S";
    public bool wasLeftOfDead = false;

    public GlobalState globalState;

    // Start is called before the first frame update
    void Start() {
        globalState = GameObject.Find("GlobalState").GetComponent<GlobalState>();
    }

    // Update is called once per frame
    void Update() {
        if (transform.localPosition.y < Constants.SCANNER_BELT_Y) {
            transform.localPosition.Set(transform.localPosition.x, Constants.SCANNER_BELT_Y, transform.localPosition.z);
            direction = "E";
        }

        if (transform.localPosition.x > Constants.OUTPUT_BELT_X) {
            transform.localPosition.Set(Constants.OUTPUT_BELT_X, transform.localPosition.y, transform.localPosition.z);
            direction = "N";
        }

        if (canMove()) {
            Move();
        }

    }

    private void Move() {
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
        wasLeftOfDead = false;
    }

    private bool canMove() {
        bool leftOfDead = globalState.GetDestroyedX() > transform.localPosition.x;

        if (wasLeftOfDead && !leftOfDead) {
            Debug.Log("refresh global state");
            globalState.destroyedDNRx = 2000f;
            return true;
        }

        if (leftOfDead) {
            wasLeftOfDead = true;
        }

        return leftOfDead;
    }

    public void onDeath(){
        globalState.destroyedDNRx = gameObject.transform.localPosition.x;
        Destroy(gameObject);
    }

    void OnMouseExit()
    {
        onDeath();
    }

}
