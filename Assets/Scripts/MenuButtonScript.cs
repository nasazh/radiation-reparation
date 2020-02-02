using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonScript : MonoBehaviour {

    void OnMouseDown() {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }
}
