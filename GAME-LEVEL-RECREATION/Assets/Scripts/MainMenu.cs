using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene((int)Scene.FightingScene);
    }

    public void ControlsOption()
    {
        SceneManager.LoadScene((int)Scene.ControlsMenu);
    }

    public void SettingsOption()
    {
        SceneManager.LoadScene((int)Scene.SettingsMenu);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
