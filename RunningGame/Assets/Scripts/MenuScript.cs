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

    public void chooseRandomScene()
    {
        changeScene(globalConstants.sceneNames[Random.Range(0, globalConstants.sceneNames.Length)]);
    }

    public void reloadScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
