using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// level select script 
public class LevelSelect : MonoBehaviour
{
    public void Level1 ()
    {
        SceneManager.LoadScene("CyberSP");
    }

    public void Level2()
    {
        SceneManager.LoadScene("NordicSP");
    }

    public void Level3()
    {
        SceneManager.LoadScene("AztecSP");
    }

    public void Level4()
    {
        SceneManager.LoadScene("AtlantisSP");
    }

    public void Level5()
    {
        SceneManager.LoadScene("EgyptianSP");
    }

    public void Level6()
    {
        SceneManager.LoadScene("MarsSP");
    }

    public void startButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


}
