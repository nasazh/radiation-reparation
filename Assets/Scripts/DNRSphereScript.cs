using UnityEngine;

public class DNRSphereScript : MonoBehaviour {

    float speed = 0.5f;
    string direction = "S";

    const float SCANNER_BELT = 0f;
    const float OUTPUT_BELT = 5f;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (transform.localPosition.y < SCANNER_BELT) {
            transform.localPosition.Set(transform.localPosition.x, SCANNER_BELT, transform.localPosition.z);
            direction = "E";
        }

        if (transform.localPosition.x > OUTPUT_BELT) {
            transform.localPosition.Set(OUTPUT_BELT, transform.localPosition.y, transform.localPosition.z);
            direction = "N";
        }

        switch (direction) {
            case "S" :
                transform.Translate(Vector3.down * Time.deltaTime * speed);
                break;
            case "E" :
                transform.Translate(Vector3.right * Time.deltaTime * speed);
                break;
            case "N" :
                transform.Translate(Vector3.up * Time.deltaTime * speed);
                break;
        }

    }
}
