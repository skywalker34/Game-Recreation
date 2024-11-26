using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlsScreen : MonoBehaviour
{
    public void BackButton()
    {
        SceneManager.LoadScene((int)Scene.MainMenu);
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene((int)Scene.MainMenu);
        }
    }
}
