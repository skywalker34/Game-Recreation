using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Player player;
    public GameObject bulletPrefab;
    public Transform shootingPoint;
    public float shootInterval = 0.01f;
    public AudioSource shootingSound;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, Quaternion.identity);

        Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();
        rigidbody.velocity = player.shootingDirection * 10;
        shootingSound.Play();
    }
}
