using System.Collections.Generic;
using UnityEngine;

public class GoalBoardScript : MonoBehaviour {

    public GameObject dnr;
    public GlobalState globalState;
    public List<GameObject> currentGoal = new List<GameObject>();

    int lengthOfGoal = Constants.STARTING_GOAL_LENGTH;
    // Start is called before the first frame update
    void Start() {
        globalState = GameObject.Find("GlobalState").GetComponent<GlobalState>();
        NewGoal();
    }

    // Update is called once per frame
    void Update() {
        if (globalState.needNewGoal) {
            NewGoal();
            globalState.needNewGoal = false;
        }
    }

    void NewGoal() {
        int cumulative = 0;
        currentGoal.ForEach(g => Destroy(g));
        currentGoal = new List<GameObject>();

        for (int i = 0; i < lengthOfGoal; i++) {
            Vector3 spawnLocation = new Vector3(580 + cumulative, 835, 0);
            GameObject spawn = Instantiate(dnr, spawnLocation, Quaternion.identity);
            spawn.GetComponent<Rigidbody2D>().simulated = false;
            spawn.GetComponent<DNRSphereScript>().direction = "";
            currentGoal.Add(spawn);
            cumulative += 62;
        }

        if (lengthOfGoal < 12) lengthOfGoal++;

    }
}
