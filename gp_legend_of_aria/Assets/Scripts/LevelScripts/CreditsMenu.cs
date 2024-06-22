using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CreditsMenu : MonoBehaviour
{
    public void BackToMenu(){
        //Go back to the MainMenu
        SceneManager.LoadScene("MainMenu"); 
    }
}
