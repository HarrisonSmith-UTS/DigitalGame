using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuScript : MonoBehaviour
{

    public void Start()
    {
        Time.timeScale = globalConstants.globalTimeScale;
    }

    // Use this for initialization
    public void changeScene(string sceneName)
    {
        Time.timeScale = globalConstants.globalTimeScale;
        Input.ResetInputAxes();
        SceneManager.LoadScene(sceneName);
    }

    public void chooseRandomScene()
    {
        changeScene(globalConstants.sceneNames[Random.Range(0, globalConstants.sceneNames.Length)]);
    }

    public void reloadScene()
    {
        Time.timeScale = globalConstants.globalTimeScale;
        Input.ResetInputAxes();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
