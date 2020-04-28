using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Level Select");
    }

    public void Help()
    {
        SceneManager.LoadScene("Help");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Highscore()
    {
        SceneManager.LoadScene("High Score Table");
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("Start Screen");
    }
}
