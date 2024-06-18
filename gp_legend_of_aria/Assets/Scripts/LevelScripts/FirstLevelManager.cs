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

    // private void HandlePartCompletion()
    // {
    //     switch (currentPart)
    //     {
    //         case LevelPart.Part1:
    //             // Open the door to Part 2
    //             if (doorPart1ToPart2 != null)
    //             {
    //                 doorPart1ToPart2.SetActive(false); // Assume the door is deactivated to open
    //             }
    //             currentPart = LevelPart.Part2;
    //             CountEnemies(); // Count enemies for the next part
    //             break;

    //         case LevelPart.Part2:
    //             // Open the door to Part 3
    //             if (doorPart2ToPart3 != null)
    //             {
    //                 doorPart2ToPart3.SetActive(false); // Assume the door is deactivated to open
    //             }
    //             currentPart = LevelPart.Part3;
    //             CountEnemies(); // Count enemies for the next part
    //             break;

    //         case LevelPart.Part3:
    //             // Transition to the next level
    //             GameManager.instance.OnLevelCompleted();
    //             break;
    //     }
    // }
}
