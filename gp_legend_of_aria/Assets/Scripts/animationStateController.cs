using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    int isRunningHash;

    //new
    int isEmottingHash;

    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");

        //new
        isEmottingHash = Animator.StringToHash("isEmotting");
    }

    // Update is called once per frame
    void Update()
    {
        //new
        bool isrunning = animator.GetBool(isRunningHash);
        bool isWalking = animator.GetBool(isWalkingHash);

        //new for emote
        bool isEmotting = animator.GetBool(isEmottingHash);


        bool forwardPressed = Input.GetKey("w");
        //new stuff for multidirectional movement
        bool backwardPressed = Input.GetKey("s");
        bool leftwardPressed = Input.GetKey("a");
        bool rightwardPressed = Input.GetKey("d");

        //new for running
        bool runPressed = Input.GetKey("left shift");
        //new for emote
        bool emotePressed = Input.GetKey("g");

        //new ifs for emote
        if(!isEmotting && !isWalking &&emotePressed){
            animator.SetBool(isEmottingHash, true);
        }

        if(isEmotting && emotePressed){
            animator.SetBool(isEmottingHash, false);
        }
        
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

    }
}