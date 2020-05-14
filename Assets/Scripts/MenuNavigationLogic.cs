using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuNavigationLogic : MonoBehaviour
{
    public GameObject settings;
    public void OpenMainMenu()
    {
        Debug.Log("Back button clicked");
        SceneManager.LoadScene("MainMenu");
    }
    public void OpenCredits()
    {
        Debug.Log("Credits clicked");
        SceneManager.LoadScene("Credits");
    }

    public void OpenLevel1()
    {
        Debug.Log("StartGame clicked");
        SceneManager.LoadScene("Proto5");
    }

    public void QuitGame()
    {
        Debug.Log("Quit clicked");
        Application.Quit();
    }

    public void OpenSettings()
    {
        settings.SetActive(true);
    }
}