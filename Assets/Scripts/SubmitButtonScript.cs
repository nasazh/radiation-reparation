using UnityEngine;

public class SubmitButtonScript : MonoBehaviour {

    public GlobalState globalState;

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
        Debug.Log("Submit");
        globalState.needNewGoal = true;
    }
}
