using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadiationGunScript : MonoBehaviour
{

    public GameObject bolt;
    bool charging = false;
    float timer = 0;
    public GlobalState globalState;

    // Start is called before the first frame update
    void Start()
    {
        globalState = GameObject.Find("GlobalState").GetComponent<GlobalState>();
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
            transform.Translate(Vector3.left * Time.deltaTime * Constants.BALLS_SPEED * Constants.GUN_SPEED_MULTIPLIER);
        }
        if (Input.GetKey(KeyCode.L)){
            transform.Translate(Vector3.right * Time.deltaTime * Constants.BALLS_SPEED * Constants.GUN_SPEED_MULTIPLIER);
        }
        if (gameObject.transform.localPosition.x < globalState.radiationGunMinX) {
            Vector3 getBackLocation = new Vector3(globalState.radiationGunMinX, transform.localPosition.y, transform.localPosition.z);
            gameObject.transform.SetPositionAndRotation(getBackLocation, Quaternion.identity);
        }
        if (gameObject.transform.localPosition.x > globalState.radiationGunMaxX) {
            Vector3 getBackLocation = new Vector3(globalState.radiationGunMaxX, transform.localPosition.y, transform.localPosition.z);
            gameObject.transform.SetPositionAndRotation(getBackLocation, Quaternion.identity);
        }
        globalState.dnrGunMaxX = transform.localPosition.x - Constants.DISTANCE_BETWEEN_GUNS;
    }

    private void shoot() {
        Vector3 spawnLocation = new Vector3(transform.localPosition.x - 15, transform.localPosition.y + 70, transform.localPosition.z + 1);
        Instantiate(bolt, spawnLocation, Quaternion.identity);
        charging = true;
    }
}
