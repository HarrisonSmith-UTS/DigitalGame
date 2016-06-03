using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuScript : MonoBehaviour
{

    // Use this for initialization
    public void changeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
