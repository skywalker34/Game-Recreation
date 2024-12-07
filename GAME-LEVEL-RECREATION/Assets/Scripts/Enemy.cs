using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public NavMeshAgent agent;

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

        //if (Mathf.Abs(targetPos.y - currentPos.y) > 0)
        //{
        //    Debug.Log("x: ");
        //    Debug.Log(targetPos.y);
        //    targetPos.x = currentPos.x;
        //}
        //else
        //{
        //    Debug.Log("y: ");
        //    Debug.Log(targetPos.y);
        //    targetPos.y = currentPos.y;
        //}
        //if (Mathf.Abs(agent.velocity.x) > Mathf.Abs(agent.velocity.y))
        //{
        //    Debug.Log("x: ");
        //    Debug.Log(agent.velocity.x);
        //}
        //else
        //{
        //    Debug.Log("y: ");
        //    Debug.Log(agent.velocity.y);
        //}

        agent.SetDestination(targetPos);

    }
}
