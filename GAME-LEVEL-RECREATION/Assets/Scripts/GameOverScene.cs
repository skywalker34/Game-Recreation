using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScene : MonoBehaviour
{
     public void ReStartGame()
    {
        SceneManager.LoadScene("StartScreen");
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("StartScreen");
        }
    }
}
