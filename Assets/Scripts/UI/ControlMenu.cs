using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMenu : MonoBehaviour
{
    public GameObject controlMenu;
    public GameObject pauseMenuUI;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            controlMenu.SetActive(false);
            pauseMenuUI.SetActive(true);
        }
    }
    public void CloseMenu()
    {
        controlMenu.SetActive(false);
        pauseMenuUI.SetActive(true);
    }
}
