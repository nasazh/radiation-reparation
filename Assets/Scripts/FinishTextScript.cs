using UnityEngine;
using UnityEngine.UI;

public class FinishTextScript : MonoBehaviour
{
    public GlobalState globalState;
    Text text;

    // Start is called before the first frame update
    void Start()
    {
        globalState = GameObject.Find("GlobalState").GetComponent<GlobalState>();
        text = GetComponent<Text>();
        if (globalState != null) {
            text.text = "Succesful DNR repairs: " + globalState.correctGoal + "\n" + "Failed attempts: " + globalState.failedGoal;
            Destroy(globalState.gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
