using UnityEngine;

public class DNRSpawnerScript : MonoBehaviour {

    public GameObject dnr;
    public GlobalState globalState;

    float timer = 0f;
    // Start is called before the first frame update
    void Start() {
        globalState = GameObject.Find("GlobalState").GetComponent<GlobalState>();
        int commulative = 0;
        for(int i = 0; i < 11; i++) {
            Vector3 spawnLocation = new Vector3(transform.localPosition.x, transform.localPosition.y - commulative, transform.localPosition.z);
            GameObject spawn = Instantiate(dnr, spawnLocation, Quaternion.identity);
            spawn.GetComponent<Rigidbody2D>().simulated = true;

            commulative += 62;
        }
        commulative = 0;
        for(int i = 0; i < 20; i++) {
            Vector3 spawnLocation = new Vector3(transform.localPosition.x + commulative, Constants.SCANNER_BELT_Y, transform.localPosition.z);
            GameObject spawn = Instantiate(dnr, spawnLocation, Quaternion.identity);
            spawn.GetComponent<Rigidbody2D>().simulated = true;

            commulative += 62;
        }
    }

    // Update is called once per frame
    void Update() {
        if (globalState.pauseTime) {
            timer -= Constants.DNR_SPAWN_TIME;
            globalState.pauseTime = false;
        }

        timer += Time.deltaTime;

        if (timer >= Constants.DNR_SPAWN_TIME)
        {
            GameObject spawn = Instantiate(dnr, transform.localPosition, Quaternion.identity);
            spawn.GetComponent<Rigidbody2D>().simulated = true;
            timer = 0;
        }

    }
}
