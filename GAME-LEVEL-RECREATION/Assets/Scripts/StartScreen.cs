using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("RealGame");
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
          SceneManager.LoadScene("StartScreen");
        }
    }
}
