using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        // Load the game scene
        SceneManager.LoadScene("FirstLevel"); 

        //GameManager.instance.ChangeState(GameManager.GameState.Playing);
    }

    public void CreditScene(){
        SceneManager.LoadScene("CreditsScene");
    }

    public void QuitGame()
    {
        // Quit the application
        Application.Quit();
    }
}
