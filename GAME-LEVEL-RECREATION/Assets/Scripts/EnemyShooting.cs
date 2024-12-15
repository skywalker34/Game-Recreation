using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public Enemy enemy;
    public GameObject bulletPrefab;
    public Transform shootingPoint;
    public float shootInterval = 5.0f;
    public AudioSource shootingSound;


    void Start()
    {
        InvokeRepeating("Shoot", shootInterval, shootInterval);
    }

    void Shoot()
    {
        if(!enemy.isDead)
        {
            GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, Quaternion.identity);

            Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();
            rigidbody.velocity = enemy.shootingDirection * 10;
            shootingSound.Play();
        }
    }
}
