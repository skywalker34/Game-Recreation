using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public NavMeshAgent agent;
    public Vector2 shootingDirection;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("target: ");
        Debug.Log(target.position);
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 targetPos = target.position;
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

        agent.SetDestination(targetPos);

    }
}
