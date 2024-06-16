using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        // Load the game scene
        SceneManager.LoadScene("SampleScene"); // Replace "GameScene" with the name of your game scene
    }

    public void QuitGame()
    {
        // Quit the application
        Application.Quit();
        
        // For testing in the Unity editor
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
