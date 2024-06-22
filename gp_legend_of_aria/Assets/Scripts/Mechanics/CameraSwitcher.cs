using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera sideViewCamera; // Drag your side view camera here in the inspector
    public Camera topDownCamera;  // Drag your top down camera here in the inspector

    void Start()
    {
        // Ensure only the side view camera is active at the start
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
