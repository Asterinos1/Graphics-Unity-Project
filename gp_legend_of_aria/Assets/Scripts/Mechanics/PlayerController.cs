using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public AudioSource attackSound;
    public float speed = 5.0f;
    public float rotationSpeed = 1200.0f;
    public float sprintMultiplier = 1.5f;
    public int attackDamage = 1;
    public float attackDelay = 0.2f;
    private Transform playerTransform;
    private float currentSpeed;
    private bool isAttacking = false;

    void Start()
    {
        playerTransform = GetComponent<Transform>();
    }

    void Update()
    {
        //walkSound.Stop();
        MovePlayer();

        if (Input.GetKeyDown(KeyCode.Space) && !isAttacking)
        {
            StartCoroutine(Attack());
        }


         if (Input.GetKeyDown(KeyCode.R))
        {
            FirstLevelManager firstLevelManager = FindObjectOfType<FirstLevelManager>();
            SecondLevelManager secondLevelManager = FindObjectOfType<SecondLevelManager>();
            ThirdLevelManager thirdLevelManager = FindObjectOfType<ThirdLevelManager>();

            if (firstLevelManager != null)
            {
                SceneManager.LoadScene("FirstLevel");
            }
            else if (secondLevelManager != null)
            {
                SceneManager.LoadScene("SecondLevel");
            }
            else if (thirdLevelManager != null)
            {
                SceneManager.LoadScene("ThirdLevel");
            }
        }
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

    IEnumerator Attack()
    {
        isAttacking = true;

        yield return new WaitForSeconds(attackDelay);

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 1.5f); // Adjust the radius as needed
        foreach (var hitCollider in hitColliders)
        {
            attackSound.Play();
            if (hitCollider.CompareTag("Enemy"))
            {
                Health enemyHealth = hitCollider.GetComponent<Health>();
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(attackDamage);
                }
            }
        }

        isAttacking = false;
    }
}