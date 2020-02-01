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
            transform.Translate(Vector3.left * Time.deltaTime * Constants.BALLS_SPEED * 2);
            if (!alreadyShot) readyToShoot.gameObject.transform.Translate(Vector3.left * Time.deltaTime * Constants.BALLS_SPEED * 2);
        }
        if (Input.GetKey(KeyCode.D)){
            transform.Translate(Vector3.right * Time.deltaTime * Constants.BALLS_SPEED * 2);
            if (!alreadyShot) readyToShoot.gameObject.transform.Translate(Vector3.right * Time.deltaTime * Constants.BALLS_SPEED * 2);
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
