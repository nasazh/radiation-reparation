using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadiationGunScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.I)){
            shoot();
        }
        if (Input.GetKey(KeyCode.J)){
            transform.Translate(Vector3.left * Time.deltaTime * Constants.BALLS_SPEED * 2);
        }
        if (Input.GetKey(KeyCode.L)){
            transform.Translate(Vector3.right * Time.deltaTime * Constants.BALLS_SPEED * 2);
        }
    }

    private void shoot() {

    }
}
