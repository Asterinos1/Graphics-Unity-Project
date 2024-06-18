using UnityEngine;

public class MainMenuMusicManager : MonoBehaviour
{
    private static MainMenuMusicManager instance;
    private AudioSource audioSource;

    void Awake()
    {
        // If an instance of this class does not exist, set it as the instance and do not destroy it on load
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If an instance already exists and it's not this one, destroy this gameObject
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }

        audioSource = GetComponent<AudioSource>();
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}
