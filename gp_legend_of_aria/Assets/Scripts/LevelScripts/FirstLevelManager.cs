using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstLevelManager : MonoBehaviour
{
    private int enemyCount;
    private int initialEnemyCount;
    public Collider DoorCollider1;
    public Collider DoorCollider2;

    private int lionStatuesOnCarpetCount = 0;
    public int requiredLionStatuesOnCarpet = 2; // The required number of lion statues on carpets

    private void Start()
    {
        // Count all enemies at the start
        initialEnemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        enemyCount = initialEnemyCount;
        Debug.Log("Enemies found: " + enemyCount);
        Debug.Log("Half enemies: " + initialEnemyCount / 2);
    }

    public void OnEnemyKilled()
    {
        enemyCount--;
        Debug.Log("Enemies remaining: " + enemyCount);
        CheckDoorConditions();
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

    private void Update()
    {
        CheckDoorConditions();
    }

    private void CheckDoorConditions()
    {
        //Debug.Log("Checking door conditions...");
        // Check conditions for door 1
        if (enemyCount <= initialEnemyCount / 2 && lionStatuesOnCarpetCount >= requiredLionStatuesOnCarpet && DoorCollider1 != null)
        {
            Debug.Log("Conditions met for opening door 1.");
            Destroy(DoorCollider1); // Remove the first door collider
            DoorCollider1 = null; // Set to null to prevent multiple attempts to destroy
        }

        // Check conditions for door 2
        if (enemyCount == 0 && lionStatuesOnCarpetCount >= requiredLionStatuesOnCarpet + 4 && DoorCollider2 != null)
        {
            Debug.Log("Conditions met for opening door 2.");
            Destroy(DoorCollider2); // Remove the second door collider
            DoorCollider2 = null; // Set to null to prevent multiple attempts to destroy
        }
    }
}
