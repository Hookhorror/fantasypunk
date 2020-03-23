using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuNavigationLogic : MonoBehaviour
{
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
        SceneManager.LoadScene("Test");
    }

    public void QuitGame()
    {
        Debug.Log("Quit clicked");
        Application.Quit();
    }
}