using System.Collections.Generic;
using UnityEngine;

public class SubmitButtonScript : MonoBehaviour {

    public GlobalState globalState;
    public GoalBoardScript goalBoard;

    // Start is called before the first frame update
    void Start() {
        globalState = GameObject.Find("GlobalState").GetComponent<GlobalState>();

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyUp(KeyCode.Space)) {
            Submit();
        }
    }

    void OnMouseDown() {
        Submit();
    }

    public void Submit() {
        List<DNRSphereScript> scannerLine = new List<DNRSphereScript>();
        DNRSphereScript[] allDNR = GameObject.FindObjectsOfType<DNRSphereScript>();
        for (int i = 0; i < allDNR.Length; i++) {
            if (Mathf.RoundToInt(allDNR[i].gameObject.transform.localPosition.y) == Mathf.RoundToInt(Constants.SCANNER_BELT_Y)) {
                scannerLine.Add(allDNR[i]);
            }
        }

        scannerLine.Sort((a, b) => Mathf.RoundToInt(a.gameObject.transform.localPosition.x - b.gameObject.transform.localPosition.x));

        PrintList(scannerLine);
        PrintListObject(goalBoard.currentGoal);
        for (int i = 0; i < scannerLine.Count - goalBoard.currentGoal.Count; i++) {
            if (scannerLine[i].value == goalBoard.currentGoal[0].GetComponent<DNRSphereScript>().value) {
                var fits = 1;
                for (int j = 1; j < goalBoard.currentGoal.Count; j++) {
                    if (scannerLine[i + j].value == goalBoard.currentGoal[j].GetComponent<DNRSphereScript>().value) {
                        fits++;
                    }
                }
                if (fits == goalBoard.currentGoal.Count) {
                    CorrectGoal();
                    return;
                }
            }
        }

        FailedGoal();
    }

    private void CorrectGoal() {
        globalState.needNewGoal = true;
        globalState.correctGoal += 1;

    }

    private void FailedGoal() {
        globalState.failedGoal += 1;
    }

    private void PrintList(List<DNRSphereScript> scannerLine10) {
        string result = "";
        scannerLine10.ForEach(a => {
            result = result + ", " + a.value;
        });
        Debug.Log("Scanner Line = " + result);
    }

    private void PrintListObject(List<GameObject> goalBoardCurrentGoal0) {
        string result = "";
        goalBoardCurrentGoal0.ForEach(a => {
            result = result + ", " + a.GetComponent<DNRSphereScript>().value;
        });
        Debug.Log("Goal Line = " + result);
    }
}
