using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonScript : MonoBehaviour {

    Vector3 scaleChange = new Vector3(-0.01f, -0.01f, -0.01f);

    void OnMouseUp() {
        gameObject.transform.localScale -= scaleChange;
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

    void OnMouseDown() {
        gameObject.transform.localScale += scaleChange;
    }
}
