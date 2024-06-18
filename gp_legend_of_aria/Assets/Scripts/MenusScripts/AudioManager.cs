using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        // Check the current scene
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name != "MainMenu" && currentScene.name != "CreditsScene")
        {
            // If the current scene is neither the MainMenu nor CreditsScene, destroy the audio manager
            Destroy(gameObject);
        }
    }
}
