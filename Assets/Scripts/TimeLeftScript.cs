using UnityEngine;
using UnityEngine.UI;

public class TimeLeftScript : MonoBehaviour
{
    int timeLeft = Constants.GAME_TIME;
    float timer = 0;
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        text.text = "" + Mathf.RoundToInt(timeLeft - timer);
        if (timeLeft - timer <= 0) {
            finishGame();
        }
    }

    private void finishGame() {

    }
}
