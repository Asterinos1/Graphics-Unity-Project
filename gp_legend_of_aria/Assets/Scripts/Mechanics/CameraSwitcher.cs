using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera sideViewCamera; 
    public Camera topDownCamera;  

    void Start()
    {
        sideViewCamera.gameObject.SetActive(true);
        topDownCamera.gameObject.SetActive(false);
    }

    void Update()
    {
        // Toggle between cameras
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            sideViewCamera.gameObject.SetActive(true);
            topDownCamera.gameObject.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            sideViewCamera.gameObject.SetActive(false);
            topDownCamera.gameObject.SetActive(true);
        }
    }
}
