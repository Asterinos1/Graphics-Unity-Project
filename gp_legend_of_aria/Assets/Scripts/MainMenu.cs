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

        // For debbuging
        // If we are running in the editor, simulate the quit
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
