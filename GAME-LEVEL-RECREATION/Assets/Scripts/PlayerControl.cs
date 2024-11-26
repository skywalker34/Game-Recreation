using System;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private PlayerNumber playerNumber;
    public GameObject shield;
    public Shield _shield;
    public Rigidbody2D playerRigidbody;
    public Transform groundCheck;
    public Transform roofCheck;
    public Transform shieldTransform;
    public LayerMask groundLayer;
    public LayerMask roofLayer;
    public SpriteRenderer spriteRenderer;

    Vector2 velocity;
    int gravityScale = 1;
    bool isGrounded;
    bool isRoof;
    bool isForwardDirection;

    [Header("Sounds")]
    public AudioSource jump, dash, shieldActivate;

    void Start()
    {
        isForwardDirection = playerNumber == PlayerNumber.One;
        shield.SetActive(false);
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        isRoof = Physics2D.OverlapCircle(roofCheck.position, 0.1f, roofLayer);

        SetVerticalVelocity();
        SetMovement();
        ResetGravityScale();
        UpdateShieldPosition();
    }

    void SetVerticalVelocity()
    {
        if (isGrounded && velocity.y <= 0)
        {
            velocity.y = 0;
        }
        else if (isRoof && velocity.y >= 0)
        {
            velocity.y = 0;
        }
        else if (playerRigidbody.gravityScale == 1)
        {
            velocity.y += Constants.GRAVITY * Time.deltaTime;
            playerRigidbody.AddForce(new Vector2(0, velocity.y));
        }
        else if (playerRigidbody.gravityScale == -1)
        {
            velocity.y += -Constants.GRAVITY * Time.deltaTime;
            playerRigidbody.AddForce(new Vector2(0, velocity.y));
        }
    }

    void SetMovement()
    {
        if ((playerNumber == PlayerNumber.One && Input.GetKey(KeyCode.D)) || (playerNumber == PlayerNumber.Two && Input.GetKey(KeyCode.L)))
        {
            isForwardDirection = true;
            playerRigidbody.velocity = new Vector2(GetHorizontalSpeed(), playerRigidbody.velocity.y);
        }
        if ((playerNumber == PlayerNumber.One && Input.GetKey(KeyCode.A)) || (playerNumber == PlayerNumber.Two && Input.GetKey(KeyCode.J)))
        {
            isForwardDirection = false;
            playerRigidbody.velocity = new Vector2(-GetHorizontalSpeed(), playerRigidbody.velocity.y);
        }
        spriteRenderer.flipX = isForwardDirection;
        if ((playerNumber == PlayerNumber.One && Input.GetKeyDown(KeyCode.W)) || (playerNumber == PlayerNumber.Two && Input.GetKeyDown(KeyCode.I)))
        {
            if (isRoof && CanActivateShield())
            {
                shield.SetActive(true);
                shieldActivate.Play();
                return;
            }
            shield.SetActive(false);
            gravityScale = isGrounded ? 1 : -1;
            spriteRenderer.flipY = !isGrounded;
            playerRigidbody.gravityScale = gravityScale;
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, Constants.VERTICAL_SPEED);
            if (!isRoof)
            {
                jump.Play();
            }
        }
        if ((playerNumber == PlayerNumber.One && Input.GetKeyDown(KeyCode.S)) || (playerNumber == PlayerNumber.Two && Input.GetKeyDown(KeyCode.K)))
        {
            if (isGrounded && CanActivateShield())
            {
                shield.SetActive(true);
                shieldActivate.Play();
                return;
            }
            shield.SetActive(false);
            gravityScale = isRoof ? -1 : 1;
            spriteRenderer.flipY = isRoof;
            playerRigidbody.gravityScale = gravityScale;
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, -Constants.VERTICAL_SPEED);
            if (!isGrounded)
            {
                jump.Play();
            }

        }
        if ((playerNumber == PlayerNumber.One && Input.GetKeyDown(KeyCode.Q)) || (playerNumber == PlayerNumber.Two && Input.GetKeyDown(KeyCode.U)))
        {
            shield.SetActive(false);
            playerRigidbody.gravityScale = isGrounded ? playerRigidbody.gravityScale : 0;
            playerRigidbody.velocity = new Vector2(isForwardDirection ? Constants.DASHING_SPEED : -Constants.DASHING_SPEED, 0);
            dash.Play();
        }
    }

    float GetHorizontalSpeed()
    {
        return Math.Abs(playerRigidbody.velocity.x) > Constants.HORIZONTAL_SPEED ? Math.Abs(playerRigidbody.velocity.x) : Constants.HORIZONTAL_SPEED;
    }

    void ResetGravityScale() {
        if (playerRigidbody.gravityScale == 0 && Math.Abs(playerRigidbody.velocity.x) < Constants.HORIZONTAL_SPEED)
        {
            playerRigidbody.gravityScale = gravityScale;
        }
    }

    void UpdateShieldPosition()
    {
        if (shield != null)
        {
            float player_X = playerRigidbody.transform.position.x;
            shield.transform.position = new Vector2(isForwardDirection ? player_X + Constants.SHIELD_POSITION : player_X - Constants.SHIELD_POSITION, playerRigidbody.transform.position.y);
        }
    }

    public bool GetDirection()
    {
        return isForwardDirection;
    }

    private bool CanActivateShield()
    {
        if(playerNumber == PlayerNumber.One && _shield.playerOneShield > 0)
        {
            return true;
        } else if(playerNumber == PlayerNumber.Two && _shield.playerTwoShield > 0)
        {
            return true;
        }else
        {
            return false;
        }
    }
}
