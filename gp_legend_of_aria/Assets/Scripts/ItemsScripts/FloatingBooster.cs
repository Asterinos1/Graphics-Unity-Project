using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingBooster : MonoBehaviour
{
    // Start is called before the first frame update
   [Tooltip("The height of the up and down movement")]
    public float amplitude = 0.5f; // The height of the up and down movement

    [Tooltip("The speed of the up and down movement")]
    public float frequency = 1f; // The speed of the up and down movement

    [Tooltip("The speed of the spinning movement")]
    public float spinSpeed = 50f; // The speed of the spinning movement

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Floating motion
        float newY = startPos.y + Mathf.Sin(Time.time * frequency) * amplitude;
        transform.position = new Vector3(startPos.x, newY, startPos.z);

        // Spinning motion
        transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);
    }

    // void OnTriggerEnter(Collider other)
    // {
    //     // Check if the colliding object is the player
    //     Health healthScript = other.GetComponent<Health>();
    //     if (healthScript != null && !healthScript.isEnemy)
    //     {
    //         // Heal the player to full health
    //         healthScript.health = healthScript.numOfHearts;

    //         // Optionally, you can add some visual or sound effects here to indicate the potion was picked up.

    //         // Destroy the potion object after being picked up
    //         Destroy(gameObject);
    //     }
    // }
}
