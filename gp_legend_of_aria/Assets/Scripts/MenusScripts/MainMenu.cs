using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public Button fullscreenToggleButton; // Reference to the Button component
    public Button selectLevelButton; // Reference to the Select Level button
    public GameObject selectLevelPanel; // Reference to the Select Level panel
    public Button level1Button; // Reference to Level 1 button
    public Button level2Button; // Reference to Level 2 button
    public Button level3Button; // Reference to Level 3 button
    public Button backButton; // Reference to the Back button

    private void Start()
    {
        // Set the initial text based on the current fullscreen state
        UpdateFullscreenButtonText();
        
        // Hide the select level panel initially
        selectLevelPanel.SetActive(false);

        // Assign button click listeners
        selectLevelButton.onClick.AddListener(ToggleSelectLevelPanel);
        level1Button.onClick.AddListener(() => LoadLevel("FirstLevel"));
        level2Button.onClick.AddListener(() => LoadLevel("SecondLevel"));
        level3Button.onClick.AddListener(() => LoadLevel("ThirdLevel"));
        backButton.onClick.AddListener(ToggleSelectLevelPanel);
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
                buttonTextTMP.text = Screen.fullScreen ? "Fullscreen" : "Window";
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

    private void ToggleSelectLevelPanel()
    {
        selectLevelPanel.SetActive(!selectLevelPanel.activeSelf);
    }

    private void LoadLevel(string levelName)
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(levelName);
    }
}
