using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f; // ���a���ʳt��
    //public GameObject bulletPrefab;
    //public Transform shootingPoint;
    public Vector2 shootingDirection;

    private Rigidbody2D rb;
    private Vector2 movement;


    void Start()
    {
        shootingDirection = Vector2.up;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal"); // A(-1), D(+1)
        movement.y = Input.GetAxisRaw("Vertical");   // W(+1), S(-1)

        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            shootingDirection = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
            shootingDirection = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            transform.rotation = Quaternion.Euler(0, 0, -180);
            shootingDirection = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0, 0, -90);
            shootingDirection = Vector2.right;
        }

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, Quaternion.identity);
        //    Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        //    bulletRigidbody.velocity = shootingDirection;
        //}

        if (movement.x != 0) movement.y = 0;
    }

    void FixedUpdate()
    {
        rb.velocity = movement * moveSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        rb.velocity = Vector2.zero;
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        rb.velocity = Vector2.zero;
    }
}