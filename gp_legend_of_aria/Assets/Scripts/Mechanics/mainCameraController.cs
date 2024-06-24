using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainCameraController : MonoBehaviour
{
    public Transform player; // Player's transform
    public float height = 10.0f; // Height above the player
    public float distance = 5.0f; // Distance behind the player
    public float angle = 45.0f; // Angle of the camera relative to the ground

    void LateUpdate()
    {
        if (player != null)
        {
            // Set the position of the camera (height) based on player's position
            transform.position = player.position - new Vector3(0, -height, distance);

            // Set the rotation of the camera
            transform.rotation = Quaternion.Euler(angle, 0, 0);

            // Always look at the player
            transform.LookAt(player);
        }
    }
}
