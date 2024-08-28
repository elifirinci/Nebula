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
                    animator.SetBool("isRunningForwardLeft", true);
                    animator.SetBool("isForwardLeft", false);
                }
                if (!moveInputShift)
                {
                    animator.SetBool("isRunningForwardLeft", false);
                }

            }

            if (moveInputD)
            {
                animator.SetBool("isForwardRight", true);
                if (moveInputShift)
                {
                    animator.SetBool("isRunningForwardRight", true);
                    animator.SetBool("isForwardRight", false);
                }
                if (!moveInputShift)
                {
                    animator.SetBool("isRunningForwardRight", false);
                }

            }
            if (!moveInputA)
            {
                animator.SetBool("isForwardRight", false);
            }

            if (moveInputShift)
            {
                //animator.SetBool("isWalk", false);
                animator.SetBool("isRunning", true);
            }

            else if (!moveInputShift)
            {
                animator.SetBool("isRunning", false);
                animator.SetBool("isRunningForwardLeft", false);
                animator.SetBool("isRunningForwardRight", false);
            }
        }
        else if (!moveInputW)
        {
            animator.SetBool("isWalk", false);
            animator.SetBool("isRunning", false);
            if (!moveInputA)
            {
                animator.SetBool("isForwardLeft", false);
            }
        }

        if (moveInputA)
        {
            animator.SetBool("isLeftStrafe", true);
            if (moveInputW)
            {
                animator.SetBool("isForwardLeft", true);
            }
            else if (!moveInputW)
            {
                animator.SetBool("isForwardLeft", false);
            }
            
        }
        else if (!moveInputA)
        {
            animator.SetBool("isLeftStrafe", false);
            animator.SetBool("isForwardLeft", false);
            animator.SetBool("isRunningForwardLeft", false);
        }

        if (moveInputS)
        {
            animator.SetBool("isBackwards",true);
        }
        else if (!moveInputS)
        {
            animator.SetBool("isBackwards",false);
        }


        if (moveInputD)
        {
            animator.SetBool("isRightStrafe", true);
            if (moveInputW)
            {
                animator.SetBool("isForwardRight", true);
            }
            else if (!moveInputW)
            {
                animator.SetBool("isForwardRight", false);
            }

        }
        else if (!moveInputD)
        {
            animator.SetBool("isRightStrafe", false);
            animator.SetBool("isForwardRight", false);
            animator.SetBool("isRunningForwardRight", false);
        }

    }
}
