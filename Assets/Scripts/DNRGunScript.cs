using UnityEngine;

public class DNRGunScript : MonoBehaviour {

    public GameObject dnr;
    DNRSphereScript readyToShoot;
    public GlobalState globalState;

    // Start is called before the first frame update
    void Start() {
        globalState = GameObject.Find("GlobalState").GetComponent<GlobalState>();
        spawnDNR();
    }

    // Update is called once per frame
    void Update() {
        var alreadyShot = readyToShoot.direction == "N";
        if (readyToShoot.direction == "E") {
            spawnDNR();
        }
        if (Input.GetKeyUp(KeyCode.W) && !alreadyShot){
            shootDNR();
        }
        if (Input.GetKey(KeyCode.A)){
            transform.Translate(Vector3.left * Time.deltaTime * Constants.BALLS_SPEED * Constants.GUN_SPEED_MULTIPLIER);
            if (!alreadyShot) readyToShoot.gameObject.transform.Translate(Vector3.left * Time.deltaTime * Constants.BALLS_SPEED * Constants.GUN_SPEED_MULTIPLIER);
        }
        if (Input.GetKey(KeyCode.D)){
            transform.Translate(Vector3.right * Time.deltaTime * Constants.BALLS_SPEED * Constants.GUN_SPEED_MULTIPLIER);
            if (!alreadyShot) readyToShoot.gameObject.transform.Translate(Vector3.right * Time.deltaTime * Constants.BALLS_SPEED * Constants.GUN_SPEED_MULTIPLIER);
        }
        if (gameObject.transform.localPosition.x < 240) {
            Vector3 getBackLocation = new Vector3(240, transform.localPosition.y, transform.localPosition.z);
            gameObject.transform.SetPositionAndRotation(getBackLocation, Quaternion.identity);
            Vector3 getBackLocation2 = new Vector3(225, readyToShoot.transform.localPosition.y, readyToShoot.transform.localPosition.z);
            if (!alreadyShot) readyToShoot.gameObject.transform.SetPositionAndRotation(getBackLocation2, Quaternion.identity);

        }
        if (gameObject.transform.localPosition.x > 1400) {
            Vector3 getBackLocation = new Vector3(1400, transform.localPosition.y, transform.localPosition.z);
            gameObject.transform.SetPositionAndRotation(getBackLocation, Quaternion.identity);
            Vector3 getBackLocation2 = new Vector3(1385, readyToShoot.transform.localPosition.y, readyToShoot.transform.localPosition.z);
            if (!alreadyShot) readyToShoot.gameObject.transform.SetPositionAndRotation(getBackLocation2, Quaternion.identity);
        }
    }

    void spawnDNR() {
        Vector3 spawnLocation = new Vector3(transform.localPosition.x - 15, transform.localPosition.y + 70, transform.localPosition.z + 1);
        readyToShoot = Instantiate(dnr, spawnLocation, Quaternion.identity).GetComponent<DNRSphereScript>();
        readyToShoot.direction = "";
    }

    void shootDNR() {
        readyToShoot.direction = "N";
        readyToShoot.GetComponent<Rigidbody2D>().simulated = true;
    }

}
