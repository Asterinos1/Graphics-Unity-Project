using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public float rotationSpeed = 1200.0f;
    public float sprintMultiplier = 1.5f;

    private Transform playerTransform;
    private float currentSpeed;

    void Start()
    {
        playerTransform = GetComponent<Transform>();
    }

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        bool isSprinting = Input.GetKey(KeyCode.LeftShift);

        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        // Apply sprint multiplier if sprinting
        currentSpeed = isSprinting ? speed * sprintMultiplier : speed;

        // Move the player
        playerTransform.Translate(direction * currentSpeed * Time.deltaTime, Space.World);

        // Rotate the player to face the direction of movement
        if (direction != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
            playerTransform.rotation = Quaternion.RotateTowards(playerTransform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
}