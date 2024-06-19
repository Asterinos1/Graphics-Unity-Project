using UnityEngine;

public class ExitCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Assuming the player has a tag "Player"
        {
            Debug.Log("Exit collider touched. Loading next level.");
            GameManager.instance.LoadNextLevel();
        }
    }
}
