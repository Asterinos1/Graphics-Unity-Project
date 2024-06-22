using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chasePlayer : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent agent;  // Holds the NavMeshAgent component
    public Transform player;     // Public variable to assign the player's transform

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();  // Get the NavMeshAgent component from the enemy object
    }

    void Update()
    {
        if (player != null)
        {
            // Update the destination of the NavMeshAgent to the player's position
            agent.SetDestination(player.position);
        }
    }
}
