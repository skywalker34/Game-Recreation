using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BaseEagleThing : MonoBehaviour
{
    // Start is called before the first frame update
     public Sprite newSprite;  // for dead animation
   public SpriteRenderer spriteRenderer;
   int hit;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
       void OnCollisionEnter2D(Collision2D bullet)
    {
        if (bullet.gameObject.tag == "Bullet") {
           
           if (hit == 4)
           {
           Invoke("changeSprite", 0.5f);
           Invoke("changeScene", 1.5f);
           }
           hit++;
        }
    }
    void changeSprite()
    {
         spriteRenderer.sprite = newSprite; 
    }
    void changeScene()
    {
         SceneManager.LoadScene("GameOver");
    }
}
