using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarpetTrigger : MonoBehaviour
{
    public FirstLevelManager firstLevelManager;
    public SecondLevelManager secondLevelManager;
    public ThirdLevelManager thirdLevelManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LionStatue"))
        {
            if (firstLevelManager != null)
            {
                firstLevelManager.OnLionStatuePlaced();
            }
            else if (secondLevelManager != null)
            {
                secondLevelManager.OnLionStatuePlaced();
            }
            else if (thirdLevelManager != null)
            {
                thirdLevelManager.OnLionStatuePlaced();
            }
            Debug.Log("Lion statue placed on carpet.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("LionStatue"))
        {
            if (firstLevelManager != null)
            {
                firstLevelManager.OnLionStatueRemoved();
            }
            else if (secondLevelManager != null)
            {
                secondLevelManager.OnLionStatueRemoved();
            }
            else if (thirdLevelManager != null)
            {
                thirdLevelManager.OnLionStatueRemoved();
            }
            Debug.Log("Lion statue removed from carpet.");
        }
    }
}
