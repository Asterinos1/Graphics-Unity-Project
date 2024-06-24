using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int health;
    public int numOfHearts;
    public bool isEnemy;  // Flag to check if the entity is an enemy
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //Debug.Log(gameObject.name + " isEnemy: " + isEnemy);
    }

    void Update()
    {
        if (!isEnemy) // Only update UI for player
        {
            if (health > numOfHearts)
            {
                health = numOfHearts;
            }

            for (int i = 0; i < hearts.Length; i++)
            {
                if (i < health)
                {
                    hearts[i].sprite = fullHeart;
                }
                else
                {
                    hearts[i].sprite = emptyHeart;
                }

                hearts[i].enabled = i < numOfHearts;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            health = 0; // Ensure health doesn't go below zero

            // Check if the gameObject is an enemy
            if (isEnemy)
            {
                // Attempt to find each level manager
                FirstLevelManager firstLevelManager = FindObjectOfType<FirstLevelManager>();
                SecondLevelManager secondLevelManager = FindObjectOfType<SecondLevelManager>();
                ThirdLevelManager thirdLevelManager = FindObjectOfType<ThirdLevelManager>();

                // Check which level manager is not null and call the OnEnemyKilled method
                if (firstLevelManager != null)
                {
                    firstLevelManager.OnEnemyKilled();
                }
                else if (secondLevelManager != null)
                {
                    secondLevelManager.OnEnemyKilled();
                }
                else if (thirdLevelManager != null)
                {
                    thirdLevelManager.OnEnemyKilled();
                }

                // Destroy the enemy
                Destroy(gameObject); // Despawn enemy immediately
            }else{

                FirstLevelManager firstLevelManager = FindObjectOfType<FirstLevelManager>();
                SecondLevelManager secondLevelManager = FindObjectOfType<SecondLevelManager>();
                ThirdLevelManager thirdLevelManager = FindObjectOfType<ThirdLevelManager>();

                if (firstLevelManager != null)
                {
                    SceneManager.LoadScene("FirstLevel");
                }
                else if (secondLevelManager != null)
                {
                    SceneManager.LoadScene("SecondLevel");
                }
                else if (thirdLevelManager != null)
                {
                    SceneManager.LoadScene("ThirdLevel");
                }
            }
        }
    }
}