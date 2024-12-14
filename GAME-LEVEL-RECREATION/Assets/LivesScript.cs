using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class LivesScript : MonoBehaviour
{
    public TMP_Text text;
    int lives = 3;
    // Start is called before the first frame update
    void Start()
    {
        text.text = lives.ToString();
    }

    // Update is called once per frame
    void Update()
    {
          if (Input.GetKeyDown(KeyCode.K))
        {
          loselife();
        }
    }

    void loselife()
    {    
        lives--;
        text.text = lives.ToString();
        if(lives == 0)
        {
           SceneManager.LoadScene("GameOver");
        }
    }
}
