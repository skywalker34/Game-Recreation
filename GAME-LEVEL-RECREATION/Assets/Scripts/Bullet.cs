using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameManager gameManager;

    [System.Obsolete]
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player1") == true)
        {
            gameManager.DispalyPlayerTwoWins();
        }
        else if (collision.gameObject.tag.Equals("Player2") == true)
        {
            gameManager.DispalyPlayerOneWins();
        }

        Destroy(gameObject);
    }
}
