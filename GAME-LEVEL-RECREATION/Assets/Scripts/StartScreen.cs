using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
          SceneManager.LoadScene("RealGame");
        }
    }
}
