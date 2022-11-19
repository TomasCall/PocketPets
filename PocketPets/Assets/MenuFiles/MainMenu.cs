using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static bool isDiffEasy;
    public static bool isDiffNormal;
    public static bool isDiffHard;
    
    public void StartTheGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void StartTheTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void PlayEasy()
    {
        isDiffEasy = true;
        isDiffNormal = false;
        isDiffHard = false;
    }

    public void PlayNormal()
    {
        isDiffEasy = false;
        isDiffNormal = true;
        isDiffHard = false;
    }

    public void PlayHard()
    {
        isDiffEasy = false;
        isDiffNormal = false;
        isDiffHard = true;
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exiting...");
    }
}