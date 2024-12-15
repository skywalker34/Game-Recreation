using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //public Canvas playerOneWins;
    //public Canvas playerTwoWins;
    //public Canvas draw;
    private bool isGamePaused = false;

    void Start()
    {
        //playerOneWins.gameObject.SetActive(false);
        //playerTwoWins.gameObject.SetActive(false);
        //draw.gameObject.SetActive(false);
    }

    void Update()
    {
        if (isGamePaused)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartGame();
            }
        }
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if(enemies.Length == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public void DispalyPlayerOneWins()
    {
        Time.timeScale = 0;
        isGamePaused = true;
        //playerOneWins.gameObject.SetActive(true); 
    }

    public void DispalyPlayerTwoWins()
    {
        Time.timeScale = 0;
        isGamePaused = true;
        //playerTwoWins.gameObject.SetActive(true);
    }

    public void DispalyDraw()
    {
        Time.timeScale = 0;
        isGamePaused = true;
        //draw.gameObject.SetActive(true);
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        isGamePaused = false;
        //playerOneWins.gameObject.SetActive(false);
        //playerTwoWins.gameObject.SetActive(false);
        //draw.gameObject.SetActive(false);
    }
}