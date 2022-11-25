using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{

    public int health;
    public int numOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

 

    
    
    void Start()
    {
        health = 3;

    }

    
    void Update()
    {
        HealthBar();

        if (health == 0)
        {
           
            
            SceneManager.LoadScene("GameOver");
           
            if (Input.GetKeyUp(KeyCode.X))
            {
               
                SceneManager.LoadScene(1);
            }
        }

    }

    private void  OnTrigger(Collider2D collision)
    {
        if (collision.gameObject.tag == "Spit")
        {
            TakeDmg(1);
        }

        Destroy(collision.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            TakeDmg(1);
        }
    }


    private void HealthBar()
    {
        numOfHearts = health;

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    private void TakeDmg(int dmg)
    {
        if (health > 0)
        {
            health -= dmg;
        }
        
    }

    private void Heal(int heal)
    {
        health += heal;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Spit")
        {
            TakeDmg(1);
            Destroy(collision.gameObject);
        }
    }





    private void OnRaspberryCollected()
    {
        if(health <= 5)
        {
            Heal(1);
        }
    }


    private void OnEnable()
    {
        
        Raspberry.OnRaspberryCollected += OnRaspberryCollected;
    }

    private void OnDisable()
    {
        
        Raspberry.OnRaspberryCollected -= OnRaspberryCollected;
    }

    


}
