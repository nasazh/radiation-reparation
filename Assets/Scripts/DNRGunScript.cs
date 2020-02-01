using UnityEngine;

public class DNRGunScript : MonoBehaviour {

    public GameObject dnr;
    DNRSphereScript readyToShoot;

    // Start is called before the first frame update
    void Start() {
        spawnDNR();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyUp(KeyCode.W)){
            shootDNR();
        }
        if (Input.GetKey(KeyCode.A)){
            transform.Translate(Vector3.left * Time.deltaTime * Constants.BALLS_SPEED * 2);
            readyToShoot.gameObject.transform.Translate(Vector3.left * Time.deltaTime * Constants.BALLS_SPEED * 2);
        }
        if (Input.GetKey(KeyCode.D)){
            transform.Translate(Vector3.right * Time.deltaTime * Constants.BALLS_SPEED * 2);
            readyToShoot.gameObject.transform.Translate(Vector3.right * Time.deltaTime * Constants.BALLS_SPEED * 2);
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
        spawnDNR();
    }

}
