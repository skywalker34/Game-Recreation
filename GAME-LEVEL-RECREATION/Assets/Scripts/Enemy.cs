using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public NavMeshAgent agent;
    public Vector2 shootingDirection;
    public Sprite[] spriteArray;  // for dead animation
    public SpriteRenderer spriteRenderer;
    int numonArray; // for sprite
    public AudioSource deathSound;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("target: ");
        Debug.Log(target.position);
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        Vector2 targetPos = target.position; //placed it here so after shooting dead wont keep moving to base
          agent.SetDestination(targetPos);
    }

    // Update is called once per frame
    void Update()
    {
       
        Vector2 currentPos = transform.position;

        if (agent.velocity.y >= 0 && Mathf.Abs(agent.velocity.x) < Mathf.Abs(agent.velocity.y))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            shootingDirection = Vector2.up;
        }
        else if (agent.velocity.x < 0 && Mathf.Abs(agent.velocity.x) > Mathf.Abs(agent.velocity.y))
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
            shootingDirection = Vector2.left;
        }
        else if (agent.velocity.y < 0 && Mathf.Abs(agent.velocity.x) < Mathf.Abs(agent.velocity.y))
        {
            transform.rotation = Quaternion.Euler(0, 0, -180);
            shootingDirection = Vector2.down;
        }
        else if (agent.velocity.x >= 0 && Mathf.Abs(agent.velocity.x) > Mathf.Abs(agent.velocity.y))
        {
            transform.rotation = Quaternion.Euler(0, 0, -90);
            shootingDirection = Vector2.right;
        }

     

    }
    //Detect collisions between the GameObjects with Colliders attached
     void OnCollisionEnter2D(Collision2D bullet)
    {
        if (bullet.gameObject.tag == "Bullet") {

            agent.SetDestination(transform.position);
           DiedSprite();
           Invoke("DiedSprite", 0.5f);
            Invoke("DiedSprite", 1.0f);
            deathSound.Play();
            
     
        }
    }

    void DiedSprite()
    {
        
             spriteRenderer.sprite = spriteArray[numonArray]; 
             numonArray++;

             if (numonArray == 2)
             {
                  Invoke("DeadBoi", 0.5f);
             }
    
    }
    void DeadBoi()
    {
        Destroy(gameObject);
    }
}
