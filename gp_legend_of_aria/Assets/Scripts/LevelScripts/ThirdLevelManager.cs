using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdLevelManager : MonoBehaviour
{
    private int enemyCount;
    private int initialEnemyCount;

    private void Start()
    {
        initialEnemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        enemyCount = initialEnemyCount;
        Debug.Log("Enemies found: " + enemyCount);
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
        Debug.Log("Lion statue placed on carpet in third level.");
        // Implement your logic for handling lion statues in the third level
    }

    public void OnLionStatueRemoved()
    {
        Debug.Log("Lion statue removed from carpet in third level.");
        // Implement your logic for handling lion statues in the third level
    }
}
