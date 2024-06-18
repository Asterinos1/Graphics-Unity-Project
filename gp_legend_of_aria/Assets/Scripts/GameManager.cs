using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    // Enum for game states
    public enum GameState { MainMenu, Playing, GameOver }
    public GameState currentState;

    // Awake is always called before any Start functions.
    // Incase of duplicates, delete them.
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        // Initialize game state
        ChangeState(GameState.MainMenu);
    }

    public void ChangeState(GameState newState)
    {
        currentState = newState;

        switch (newState)
        {
            case GameState.MainMenu:
                LoadMainMenu();
                break;
            case GameState.Playing:
                // Handle starting the game
                LoadLevel(1);
                break;
            case GameState.GameOver:
                // Handle game over
                LoadMainMenu();
                break;
        }
    }

    void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadLevel(int levelIndex)
    {
        if(levelIndex==1){
            SceneManager.LoadScene("FirstScene");
        }else if(levelIndex==2){
            SceneManager.LoadScene("SecondScene");
        }else if(levelIndex==3){
            SceneManager.LoadScene("ThirdScene");
        }else{
            SceneManager.LoadScene("MainMenu");
        }

        //string levelName = "Scene" + levelIndex;
        //SceneManager.LoadScene(levelName);
    }

    public void LevelComplete(int currentLevel)
    {
        if (currentLevel < 3)
        {
            LoadLevel(currentLevel + 1);
        }
        else
        {
            // All levels complete, go to game over or main menu
            ChangeState(GameState.GameOver);
        }
    }

    public void PlayerDied()
    {
        ChangeState(GameState.GameOver);
    }
}
