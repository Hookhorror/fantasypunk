using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject settingsMenu;
    public AudioMixer audioMixer;

    Resolution[] resolutions;
    public Dropdown resDropdown;
    private void Start() 
    {
        resolutions = Screen.resolutions;
        resDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolution = 0;

        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.width &&
                resolutions[i].height == Screen.height)
            {
            currentResolution = i;
            }
        }
        resDropdown.AddOptions(options);
        resDropdown.value = currentResolution;
        resDropdown.RefreshShownValue();
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape) &&  PauseMenu.GameIsPaused)
        {
            settingsMenu.SetActive(false);
        }
    }

    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("music", volume);
    }

    public void SetEffectVolume(float volume)
    {
        audioMixer.SetFloat("effects", volume);
    }

    public void SetFullscreen(bool ifFullscreen)
    {
        Screen.fullScreen = ifFullscreen;
    }

    public void SetResolution(int resIndex)
    {
        Resolution resolution = resolutions[resIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void CloseMenu()
    {
        settingsMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void OpenSettings()
    {
        settingsMenu.SetActive(true);
    }

    public void CloseInMainMenu()
    {
        settingsMenu.SetActive(false);
    }
}
