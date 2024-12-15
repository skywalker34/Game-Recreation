using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableBlock : MonoBehaviour
{
    int hit;
     public Sprite[] spriteArray;  // for dead animation
    public SpriteRenderer spriteRenderer;
    int numonArray; // for sprite
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
     void OnCollisionEnter2D(Collision2D bullet)
    {
        if (bullet.gameObject.tag == "Bullet" || bullet.gameObject.tag == "EnemyBullet") {
           
           hit++;
           if (hit == 2){
            DiedSprite();
            Invoke("DiedSprite", 0.1f);
            Invoke("DiedSprite", 0.2f);
           }
     
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
