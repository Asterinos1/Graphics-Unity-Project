using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        // Load the game scene
        SceneManager.LoadScene("FirstLevel");
        // GameManager.instance.ChangeState(GameManager.GameState.Playing);
        GameManager.instance.currentLevel = 1;
    }

    public void CreditScene()
    {
        SceneManager.LoadScene("CreditsScene");
    }

    public void QuitGame()
    {
        // Quit the application
        Application.Quit();

        // For debugging
        // If we are running in the editor, simulate the quit
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    public void ToggleMusic()
    {
        AudioManager audioManager = FindObjectOfType<AudioManager>();
        if (audioManager != null)
        {
            audioManager.ToggleSound();
        }
    }

    public void ToggleFullscreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
}
