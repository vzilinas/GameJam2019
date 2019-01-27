using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonsController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
