using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarpetTrigger : MonoBehaviour
{
    public FirstLevelManager levelManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LionStatue"))
        {
            levelManager.OnLionStatuePlaced();
            Debug.Log("Lion statue placed on carpet.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("LionStatue"))
        {
            levelManager.OnLionStatueRemoved();
            Debug.Log("Lion statue removed from carpet.");
        }
    }
}
