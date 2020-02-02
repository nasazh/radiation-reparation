using UnityEngine;

public class GlobalState : MonoBehaviour {

    public float destroyedDNRx = 2000f;

    public bool skipDNRSpawn = false;

    public float addedDNRx = 0f;

    public bool pauseTime = false;

    private float timer = 0;

    public bool needNewGoal = false;

    public int correctGoal = 0 ;

    public int failedGoal = 0;

    public float dnrGunMinX = 240f;
    public float dnrGunMaxX = 1400f;
    public float radiationGunMinX = 240f;
    public float radiationGunMaxX = 1400f;

    public float GetDestroyedX() {
        return destroyedDNRx;
    }

    void Update() {

        if (skipDNRSpawn) {
            timer += Time.deltaTime;

            if (timer >= Constants.DNR_SPAWN_TIME)
            {
                skipDNRSpawn = false;
                addedDNRx = 0f;
                timer = 0f;
            }
        }
    }

    void Start() {
        DontDestroyOnLoad(gameObject);
    }


}
