using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

    public Animator animator;


    string IDLE = "Idle";
    string WALK = "Walking";
    string RUNNING = "Running";
    string JUMPING = "Jumping";
    string CROUCH = "Crouch";

    //Spells strings

    void Start()
    {
        animator.SetBool("Idle", true);
    }

    public void SetRun()
	{
        animator.SetBool(IDLE, false);
        animator.SetBool(WALK, false);

        animator.SetBool(RUNNING, true);
    }

    public void SetIdle()
	{
        animator.SetBool(IDLE, true);
        animator.SetBool(WALK, false);
        animator.SetBool(RUNNING, false);
    }
}
