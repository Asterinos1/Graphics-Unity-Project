using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CreditsMenu : MonoBehaviour
{
    //Simple func for the CreditsMenu button.
    public void BackToMenu(){
        //Go back to the MainMenu
        SceneManager.LoadScene("MainMenu"); 
    }
}
