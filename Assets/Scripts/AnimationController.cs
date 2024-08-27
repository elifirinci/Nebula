using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();    
    }

    void Update()
    {
        bool moveInputW = Input.GetKey(KeyCode.W);
        bool moveInputA = Input.GetKey(KeyCode.A);
        bool moveInputD = Input.GetKey(KeyCode.D);
        bool moveInputS = Input.GetKey(KeyCode.S);
        bool moveInputShift = Input.GetKey(KeyCode.LeftShift);
        if (moveInputW)
        {
            animator.SetBool("isWalk", true);
            if (moveInputA)
            {
                animator.SetBool("isForwardLeft", true);
                if (moveInputShift)
                {
                    animator.SetBool("isRunningForwardLeft",true);
                    animator.SetBool("isForwardLeft", false);
                }
                if (!moveInputShift)
                {
                    animator.SetBool("isRunningForwardLeft", false);
                }
              
            }
            if (!moveInputA)
            {
                animator.SetBool("isForwardLeft", false);
            }
        }
        else if (!moveInputW)
        {
            animator.SetBool("isWalk", false);
            if (!moveInputA)
            {
                animator.SetBool("isForwardLeft", false);
            }
        }
    }
}
