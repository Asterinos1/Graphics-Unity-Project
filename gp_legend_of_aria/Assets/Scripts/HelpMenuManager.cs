using UnityEngine;

public class HelpMenuManager : MonoBehaviour
{
    public GameObject helpMenu; // Reference to the help menu panel

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            helpMenu.SetActive(!helpMenu.activeSelf);
        }
    }
}
