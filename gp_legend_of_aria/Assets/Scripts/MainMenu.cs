using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        // Load the game scene
        SceneManager.LoadScene("FirstLevel"); 

        GameManager.instance.ChangeState(GameManager.GameState.Playing);
    }

    public void QuitGame()
    {
        // Quit the application
        Application.Quit();
    }
}
