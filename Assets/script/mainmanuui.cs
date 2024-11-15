using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmanuui : MonoBehaviour
{
    public string SceneName;
    public void Startgame()
    {
        SceneManager.LoadScene(SceneName);
        Time.timeScale = 1;
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
