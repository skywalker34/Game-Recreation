using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] private PlayerNumber playerNumber;
    public string targetTag = "Bullet";
    public int playerOneShield = 3;
    public int playerTwoShield = 3;

    [Header("Sounds")]
    public AudioSource shieldSuccess;


    private void OnCollisionEnter2D(Collision2D bullet)
    {
        if (bullet.gameObject.tag.Equals(targetTag)) {
            HitByBullet();
        }
    }

    void HitByBullet()
    {
        if(playerNumber == PlayerNumber.One && playerOneShield > 0)
        {
            playerOneShield--;
            shieldSuccess.Play();
        }
        else if (playerNumber == PlayerNumber.Two && playerTwoShield > 0)
        {
            playerTwoShield--;
            shieldSuccess.Play();
        }
        gameObject.SetActive(false);
    }
}
