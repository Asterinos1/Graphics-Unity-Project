using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float chaseRange = 10f;
    public float attackRange = 2f;
    public float patrolRadius = 5f;
    public float attackDelay = 1.5f;

    private NavMeshAgent agent;
    private float lastAttackTime;
    private Vector3 initialPosition;

    // New parameters
    public float patrolSpeed = 3.5f;
    public float chaseSpeed = 4.5f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        initialPosition = transform.position;
        lastAttackTime = -attackDelay; // Ensures the enemy can attack immediately the first time
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(player.position, transform.position);

        if (distanceToPlayer <= attackRange)
        {
            AttackPlayer();
        }
        else if (distanceToPlayer <= chaseRange)
        {
            ChasePlayer();
        }
        else
        {
            Patrol();
        }
    }

    void Patrol()
    {
        agent.speed = patrolSpeed; // Set speed for patrolling
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            Vector3 newPatrolPoint = initialPosition + Random.insideUnitSphere * patrolRadius;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(newPatrolPoint, out hit, patrolRadius, 1))
            {
                agent.SetDestination(hit.position);
            }
        }
    }

    void ChasePlayer()
    {
        agent.speed = chaseSpeed; // Set speed for chasing  
        agent.SetDestination(player.position);
    }

    void AttackPlayer()
    {
        if (Time.time - lastAttackTime >= attackDelay)
        {
            // Implement your attack logic here, e.g., reducing player's health
            Debug.Log("Attacking player");
            lastAttackTime = Time.time;

            // Example to reduce player health, assuming player has a Health component
            Health playerHealth = player.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1);
            }
        }

        // Ensure the enemy stops moving to "perform" the attack
        agent.SetDestination(transform.position);
    }
}
