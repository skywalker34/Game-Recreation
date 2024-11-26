using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameManager gameManager;

    public void Rematch()
    {
        gameManager.StartGame();
        SceneManager.LoadScene((int)Scene.FightingScene);
    }

    public void MainMenuOption()
    {
        gameManager.StartGame();
        SceneManager.LoadScene((int)Scene.MainMenu);
    }
}
