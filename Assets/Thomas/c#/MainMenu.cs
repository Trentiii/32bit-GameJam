using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public PlayerDeath playerDeath;

    public void OpenTheGame()
    {
        SceneManager.LoadScene(1);
        Debug.Log("starting...");
    }

    public void Retry()
    {
        playerDeath.timer = 10;
        print("Reset 1");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void credits()
    {
        //SceneManager.LoadScene(1);
        Debug.Log("credits?");
    }
    public void MainMenuLoad()
    {
        SceneManager.LoadScene(0);
        Debug.Log("credits?");
    }


}
