using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int currentLevel = 1;
    private int maxLevel = 3;

    private void Awake()
    {
        // Singleton pattern to ensure only one instance of GameManager exists
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

    public void setCurrentLevel(int num){
        currentLevel=num;
    }

    public void LoadNextLevel()
    {
        if (currentLevel < maxLevel)
        {
            currentLevel++;
            LoadLevel(currentLevel);
        }
        else
        {
            // If it's the last level, go to Main Menu or show some end game screen
            LoadMainMenu();
        }
    }

    private void LoadLevel(int level)
    {
        if (level == 1)
        {
            Debug.Log("Now entering Level 1");
            SceneManager.LoadScene("FirstLevel");
        }
        else if (level == 2)
        {
            Debug.Log("Now entering Level 2");
            SceneManager.LoadScene("SecondLevel");
        }
        else if (level == 3)
        {
            Debug.Log("Now entering Level 3");
            SceneManager.LoadScene("ThirdLevel");
        }else if(level == 4){

            Debug.Log("Finished! Back to main menu");
            setCurrentLevel(1);
            LoadMainMenu();
        }   

        // Alternatively, if your level scenes are named consistently:
        // string levelName = "Level" + level.ToString();
        // SceneManager.LoadScene(levelName);
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // Method to be called when the player completes the goal in a level
    public void OnLevelCompleted()
    {
        // You can add any additional logic here, such as showing a level complete screen
        LoadNextLevel();
    }
}
