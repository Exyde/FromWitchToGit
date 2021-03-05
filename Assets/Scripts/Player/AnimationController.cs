using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
	#region Fields
	Animator animator;

    string IDLE = "Idle";
    string WALK = "Walking";
    string RUNNING = "Running";
    string JUMPING = "Jumping";
    string CROUCH = "Crouch";

    //Spells strings
    string LEFT_SPELL = "LeftSpell";
    string RIGHT_SPELL = "RightSpell";
    string CAST_SPELL = "CastSpell";
	#endregion

	void Start()
    {
        animator = GetComponentInChildren<Animator>();
        animator.SetBool("Idle", true);
    }

    public void SetIdle()
	{
        animator.SetBool(IDLE, true);
        animator.SetBool(WALK, false);
        animator.SetBool(RUNNING, false);
    }

    public void SetWalk()
    {
        animator.SetBool(IDLE, false);
        animator.SetBool(WALK, true);
        animator.SetBool(RUNNING, false);
    }

    public void SetRun()
	{
        animator.SetBool(IDLE, false);
        animator.SetBool(WALK, true);
        animator.SetBool(RUNNING, true);
    }

    public void SetJump()
	{
        animator.SetTrigger(JUMPING);
	}

    public void SetLeftSpell()
	{
        animator.SetTrigger(LEFT_SPELL);
	}
    public void SetRightSpell()
    {
        animator.SetTrigger(RIGHT_SPELL);
    }
}
