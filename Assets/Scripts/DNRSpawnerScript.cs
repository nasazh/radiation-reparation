using UnityEngine;

public class DNRSpawnerScript : MonoBehaviour {

    public GameObject dnr;
    public GlobalState globalState;

    float timer = 0f;
    // Start is called before the first frame update
    void Start() {
        globalState = GameObject.Find("GlobalState").GetComponent<GlobalState>();
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
