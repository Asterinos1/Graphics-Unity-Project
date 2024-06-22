using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecondPausePanel : MonoBehaviour
{
    public GameObject pauseMenu;
    public AudioSource musicSource; // Reference to the audio source
    private bool isPaused = false;
    private bool isMusicOn = true; // Track music state

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f; // Pause the game
        isPaused = true;
        Cursor.visible = true; // Show the cursor
        Cursor.lockState = CursorLockMode.None; // Unlock the cursor
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f; // Resume the game
        isPaused = false;
        Cursor.visible = false; // Hide the cursor
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor
    }

    public void QuitToMenu()
    {
        Debug.Log("Going to the Main Menu now..");
        Time.timeScale = 1f; // Ensure time scale is reset when returning to the menu
        Cursor.visible = true; // Show the cursor in the main menu
        Cursor.lockState = CursorLockMode.None; // Unlock the cursor in the main menu
        SceneManager.LoadScene("MainMenu"); // Replace with the name of your menu scene
        //GameManager.instance.currentLevel=0;
    }

    public void ToggleMusic()
    {
        isMusicOn = !isMusicOn;
        musicSource.mute = !isMusicOn;
    }
}
