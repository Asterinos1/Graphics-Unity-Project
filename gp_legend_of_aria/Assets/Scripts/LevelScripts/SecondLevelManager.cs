using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecondLevelManager : MonoBehaviour
{
    public AudioSource doorOpened;
    private int enemyCount;
    private int initialEnemyCount;
    public Collider DoorCollider1;  // Declare the DoorCollider1 variable
    public Collider DoorCollider2;  // Declare the DoorCollider1 variable
    
    private int lionStatuesOnCarpetCount = 0;
    public int requiredLionStatuesOnCarpet = 2; // The required number of lion statues on carpets

    private void Start()
    {
        // Count all enemies at the start
        initialEnemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        enemyCount = initialEnemyCount;
        Debug.Log("Enemies found: " + enemyCount);
    }

    private void Update()
    {
        CheckDoorConditions();
    }

    private void CheckDoorConditions()
    {
        // Check conditions for door 1
        if (enemyCount == 4 && DoorCollider1 != null)
        {
            Debug.Log("Conditions met for opening door 1.");
            doorOpened.Play();
            Destroy(DoorCollider1); // Remove the first door collider
            DoorCollider1 = null; // Set to null to prevent multiple attempts to destroy
        }

        // Check conditions for door 2
        if (enemyCount == 0 && lionStatuesOnCarpetCount == requiredLionStatuesOnCarpet && DoorCollider2 != null)
        {
            Debug.Log("Conditions met for opening door 2.");
            doorOpened.Play();
            Destroy(DoorCollider2); // Remove the second door collider
            DoorCollider2 = null; // Set to null to prevent multiple attempts to destroy
        }
    }

    public void OnEnemyKilled()
    {
        enemyCount--;
        Debug.Log("Enemies remaining: " + enemyCount);
        // Check if all enemies are killed
        // if (enemyCount == 0 && DoorCollider1 != null)
        // {
        //     Debug.Log("All enemies killed. Opening door 1.");
        //     Destroy(DoorCollider1.gameObject); // Remove the door collider
        // }
    }

    public void OnLionStatuePlaced()
    {
        lionStatuesOnCarpetCount++;
        Debug.Log("Lion statues on carpets: " + lionStatuesOnCarpetCount);
        CheckDoorConditions();
    }

    public void OnLionStatueRemoved()
    {
        lionStatuesOnCarpetCount--;
        Debug.Log("Lion statues on carpets: " + lionStatuesOnCarpetCount);
    }
}
