using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private PlayerNumber playerNumber;
    [SerializeField] private ShootingDirection shootingDirection;
    public PlayerControl playerControl;
    public GameObject bulletPrefab;
    public Transform shootingPoint;
    public float shootInterval = 0.01f;

    private float lastReloadTime = 0;

    [Header("Sounds")]
    public AudioSource shoot;

    [Header("ReloadBar")]
    private int playerOneCurrentBullets;
    private int playerTwoCurrentBullets;

    public Reload reloadBar;

    private void Start()
    {
        playerOneCurrentBullets = Constants.MAX_BULLET;
        playerTwoCurrentBullets = Constants.MAX_BULLET;
        reloadBar.SetMaxShots(Constants.MAX_BULLET);
    }

    void Update()
    {
        if (playerOneCurrentBullets==0) return; 
        if ((Input.GetKeyDown(KeyCode.E)&& playerNumber == PlayerNumber.One) || (Input.GetKeyDown(KeyCode.O) && playerNumber == PlayerNumber.Two))
        {
            playerControl.shield.SetActive(false);
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        int currentBullet = playerNumber == PlayerNumber.One? playerOneCurrentBullets : playerTwoCurrentBullets;
        if (Time.time - lastReloadTime >= Constants.RELOAD_TIME && currentBullet < Constants.MAX_BULLET)
        {
            Reload();
            lastReloadTime = Time.time;
        }
    }

    

    void Shoot()
    {
        if(shootingDirection==ShootingDirection.Forward && !playerControl.GetDirection())
        {
            return;
        }
        if (shootingDirection == ShootingDirection.Backward && playerControl.GetDirection())
        {
            return;
        }
        GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, Quaternion.identity);

        Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();
        rigidbody.velocity = new Vector2(playerControl.GetDirection()? 10 : -10,0);

        LoseBullets();

        shoot.Play();

    }

    void LoseBullets()
    {
        if(playerNumber == PlayerNumber.One)
        {
            playerOneCurrentBullets--;
            reloadBar.SetShots(playerOneCurrentBullets);
        }
        else
        {
            playerTwoCurrentBullets--;
            reloadBar.SetShots(playerTwoCurrentBullets);
        }
        
    }

    void Reload()
    {
        if (playerNumber == PlayerNumber.One)
        {
            playerOneCurrentBullets++;
            reloadBar.SetShots(playerOneCurrentBullets);
        }
        else
        {
            playerTwoCurrentBullets++;
            reloadBar.SetShots(playerTwoCurrentBullets);
        }
            
    }    
}
