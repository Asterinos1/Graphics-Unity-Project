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

    public void LoadLevel(int level)
    {
        // Hide the cursor
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;

        if (level == 1)
        {
            Debug.Log("Now entering Level 1");
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            setCurrentLevel(1);
            SceneManager.LoadScene("FirstLevel");
        }
        else if (level == 2)
        {   
            Debug.Log("Now entering Level 2");
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            setCurrentLevel(2);
            SceneManager.LoadScene("SecondLevel");
        }
        else if (level == 3)
        {
            Debug.Log("Now entering Level 3");
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            setCurrentLevel(3);
            SceneManager.LoadScene("ThirdLevel");
        }else if(level == 4){

            Debug.Log("Finished! Back to main menu");
            setCurrentLevel(4);
            LoadMainMenu();
        }   
    }

    private void LoadMainMenu()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("MainMenu");
    }
}
