using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float invincibilityDuration = 5f;
   // private bool isCollected = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (isCollected) return;
        
        if(collision.CompareTag("Player1"))
        {
            //isCollected = true;

            Player player = collision.GetComponent<Player>();
            if(player != null )
            {
                player.SetInvincibility(invincibilityDuration);
            }
            Destroy(gameObject);
        }
    }
}
