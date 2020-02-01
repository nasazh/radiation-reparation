using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadiationGunScript : MonoBehaviour
{

    public GameObject bolt;
    bool charging = false;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (charging) {
            timer += Time.deltaTime;
        }
        if (timer >= Constants.DNR_SPAWN_TIME) {
            timer = 0;
            charging = false;
        }
        if (Input.GetKeyUp(KeyCode.I) && !charging){
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
        Vector3 spawnLocation = new Vector3(transform.localPosition.x - 15, transform.localPosition.y + 70, transform.localPosition.z + 1);
        Instantiate(bolt, spawnLocation, Quaternion.identity);
        charging = true;
    }
}
