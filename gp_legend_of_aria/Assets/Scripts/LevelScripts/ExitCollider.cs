using UnityEngine;
using UnityEngine.SceneManagement;
public class ExitCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Assuming the player has a tag "Player"
        {
            FirstLevelManager firstLevelManager = FindObjectOfType<FirstLevelManager>();
            SecondLevelManager secondLevelManager = FindObjectOfType<SecondLevelManager>();
            ThirdLevelManager thirdLevelManager = FindObjectOfType<ThirdLevelManager>();

            if (firstLevelManager != null)
            {
                SceneManager.LoadScene("SecondLevel");
               //GameManager.instance.LoadLevel(2);
            }
            else if (secondLevelManager != null)
            {
                SceneManager.LoadScene("ThirdLevel");
                //GameManager.instance.LoadLevel(3);
            }
            else if (thirdLevelManager != null)
            {
                SceneManager.LoadScene("MainMenu");
                //GameManager.instance.LoadLevel(4);
            }
            //Debug.Log("Exit collider touched. Loading next level.");
            //GameManager.instance.LoadNextLevel("SecondLevel");
        }
    }
}
