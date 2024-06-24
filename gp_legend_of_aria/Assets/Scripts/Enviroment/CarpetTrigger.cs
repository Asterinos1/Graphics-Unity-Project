using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarpetTrigger : MonoBehaviour
{
    public AudioSource carpetSound;
    // public FirstLevelManager firstLevelManager;
    // public SecondLevelManager secondLevelManager;
    // public ThirdLevelManager thirdLevelManager;

    private void OnTriggerEnter(Collider other)
    {
        FirstLevelManager firstLevelManager = FindObjectOfType<FirstLevelManager>();
        SecondLevelManager secondLevelManager = FindObjectOfType<SecondLevelManager>();
        ThirdLevelManager thirdLevelManager = FindObjectOfType<ThirdLevelManager>();

        if (other.CompareTag("LionStatue"))
        {
            if (firstLevelManager != null)
            {
                carpetSound.Play();
                firstLevelManager.OnLionStatuePlaced();
            }
            else if (secondLevelManager != null)
            {
                carpetSound.Play();
                secondLevelManager.OnLionStatuePlaced();
            }
            else if (thirdLevelManager != null)
            {
                carpetSound.Play();
                thirdLevelManager.OnLionStatuePlaced();
            }
            Debug.Log("Lion statue placed on carpet.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        FirstLevelManager firstLevelManager = FindObjectOfType<FirstLevelManager>();
        SecondLevelManager secondLevelManager = FindObjectOfType<SecondLevelManager>();
        ThirdLevelManager thirdLevelManager = FindObjectOfType<ThirdLevelManager>();

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
