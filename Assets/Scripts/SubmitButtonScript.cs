using System.Collections.Generic;
using UnityEngine;

public class SubmitButtonScript : MonoBehaviour {

    public GlobalState globalState;
    public GoalBoardScript goalBoard;
    Vector3 scaleChange = new Vector3(-1f, -1f, 0f);
    bool scaleChanged = false;
    float timer = 0f;

    // Start is called before the first frame update
    void Start() {
        globalState = GameObject.Find("GlobalState").GetComponent<GlobalState>();
    }

    // Update is called once per frame
    void Update() {
        if (scaleChanged) {
            timer += Time.deltaTime;
            if (timer > 0.3f) {
                gameObject.transform.localScale = new Vector3(20f, 20f, 1f);
                scaleChanged = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space)) {
            gameObject.transform.localScale += scaleChange;
            scaleChanged = true;
            timer = 0f;
            Submit();
        }
    }

    void OnMouseDown() {
        gameObject.transform.localScale += scaleChange;
        Submit();
    }

    void OnMouseUp() {
        gameObject.transform.localScale -= scaleChange;
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
}
