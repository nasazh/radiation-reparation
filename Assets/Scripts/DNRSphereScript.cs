using UnityEngine;

public class DNRSphereScript : MonoBehaviour {

    string direction = "S";

    // Start is called before the first frame update
    void Start() {

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

    }


}
