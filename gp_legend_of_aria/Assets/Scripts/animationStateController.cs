using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    int isRunningHash;  
    // Start is called before the first frame update

    //new for attack
    int isAttackingHash;
    void Start()
    {
        animator = GetComponent<Animator>();

        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
        //attack
        isAttackingHash = Animator.StringToHash("isAttacking");
    }

    // Update is called once per frame
    void Update()
    {
        //new
        bool isrunning = animator.GetBool(isRunningHash);
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isAttacking = animator.GetBool(isAttackingHash);


        bool forwardPressed = Input.GetKey("w");
        //new stuff for multidirectional movement
        bool backwardPressed = Input.GetKey("s");
        bool leftwardPressed = Input.GetKey("a");
        bool rightwardPressed = Input.GetKey("d");

        //new for running
        bool runPressed = Input.GetKey("left shift");
        bool attackPressed = Input.GetKey("space");
       
        
        if(!isWalking && (forwardPressed || leftwardPressed || rightwardPressed ||backwardPressed)){
            animator.SetBool(isWalkingHash, true);
        }

        if(isWalking && !(forwardPressed || leftwardPressed || rightwardPressed ||backwardPressed)){
            animator.SetBool(isWalkingHash, false);
        }

        //new part for running
        if(!isrunning && ((forwardPressed || leftwardPressed || rightwardPressed ||backwardPressed) && runPressed)){
            animator.SetBool(isRunningHash, true);
        }
        
        if(isrunning && (!(forwardPressed || leftwardPressed || rightwardPressed ||backwardPressed) || !runPressed)){
            animator.SetBool(isRunningHash, false);
        }

        //new for attack
        // Attack state transitions
        if (attackPressed && !isAttacking) // Check to ensure we don't restart the attack animation while attacking
            animator.SetBool(isAttackingHash, true);

        if (isAttacking && !attackPressed) // Optionally, make sure the attack animation plays fully before stopping
            animator.SetBool(isAttackingHash, false);

    }
}