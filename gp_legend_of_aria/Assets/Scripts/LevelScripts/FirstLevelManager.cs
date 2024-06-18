using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLevelManager : MonoBehaviour
{
    private int enemyCount;

    private void Start()
    {
        // Count all enemies at the start
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    public void OnEnemyKilled()
    {
        enemyCount--;

        if (enemyCount <= 0)
        {
            // All enemies are killed, notify GameManager
            GameManager.instance.OnLevelCompleted();
        }
    }
}
