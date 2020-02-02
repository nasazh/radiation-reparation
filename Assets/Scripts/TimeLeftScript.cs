using UnityEngine;
using UnityEngine.UI;

public class TimeLeftScript : MonoBehaviour
{
    int timeLeft = Constants.GAME_TIME;
    float timer = 0;
    Text text;

    public GlobalState globalState;

    // Start is called before the first frame update
    void Start()
    {
        globalState = GameObject.Find("GlobalState").GetComponent<GlobalState>();
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        text.text = "" + globalState.correctGoal + "       " + Mathf.RoundToInt(timeLeft - timer) + "       " + globalState.failedGoal;
        if (timeLeft - timer <= 0) {
            finishGame();
        }
    }

    private void finishGame() {

    }
}
