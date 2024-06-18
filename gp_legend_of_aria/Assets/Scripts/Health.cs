using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int numOfHearts;
    public bool isEnemy;  // Flag to check if the entity is an enemy
    public float knockbackForce = 5.0f; // Force of the knockback

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Debug.Log(gameObject.name + " isEnemy: " + isEnemy);
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

    public void TakeDamage(int damage, Vector3 knockbackDirection)
    {
        health -= damage;
        Debug.Log(gameObject.name + " took " + damage + " damage. Remaining health: " + health); // Log when an enemy takes damage

        if (rb != null)
        {
            rb.AddForce(knockbackDirection * knockbackForce, ForceMode.Impulse);
        }

        if (health <= 0)
        {
            health = 0; // Ensure health doesn't go below zero
            Debug.Log(gameObject.name + " health reached zero.");
            if (isEnemy)
            {
                Debug.Log(gameObject.name + " is an enemy and will be destroyed.");
                Destroy(gameObject); // Despawn enemy immediately
            }
        }
    }
}
