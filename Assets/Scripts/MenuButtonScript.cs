using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonScript : MonoBehaviour {
    public void onMouseClick() {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }
}
