using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    private AudioSource audioSource;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponentInChildren<AudioSource>();
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

    public void ToggleSound()
    {
        if (audioSource != null)
        {
            audioSource.mute = !audioSource.mute;
        }
    }

    public bool IsSoundEnabled()
    {
        return audioSource != null && !audioSource.mute;
    }
}
