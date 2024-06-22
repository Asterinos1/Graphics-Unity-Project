using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public Button fullscreenToggleButton; // Reference to the Button component

    private void Start()
    {
        // Set the initial text based on the current fullscreen state
        UpdateFullscreenButtonText();
    }

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
        // Toggle the fullscreen mode
        Screen.fullScreen = !Screen.fullScreen;

        // Update the button text
        UpdateFullscreenButtonText();
    }

    private void UpdateFullscreenButtonText()
    {
        if (fullscreenToggleButton != null)
        {
            TextMeshProUGUI buttonTextTMP = fullscreenToggleButton.GetComponentInChildren<TextMeshProUGUI>();
            if (buttonTextTMP != null)
            {
                // Log the current and new button text
                Debug.Log("Updating button text (TMP). Current text: " + buttonTextTMP.text);
                buttonTextTMP.text = Screen.fullScreen ? "Fullscreen" : "Window";
                Debug.Log("New button text (TMP): " + buttonTextTMP.text);
            }
            else
            {
                Debug.LogError("No TextMeshProUGUI component found on the fullscreen toggle button.");
            }
        }
        else
        {
            Debug.LogError("Fullscreen toggle button is not assigned.");
        }
    }
}
