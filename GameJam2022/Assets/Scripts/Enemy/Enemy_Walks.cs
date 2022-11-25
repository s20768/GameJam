using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy_Walks : StateMachineBehaviour
{
    Transform player;
    [SerializeField] private float _speed = 3f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag(Tag.PLAYER).transform;

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, player.position, _speed * Time.deltaTime);
        Vector2 lookingDirection = player.transform.position - animator.transform.position;
        animator.transform.up = new Vector2(lookingDirection.x, lookingDirection.y);
        float distance = Vector2.Distance(player.position, animator.transform.position);
        if(distance > 5f)
        {
            animator.SetBool(AnimatorValues.isWalking, false);
        } 
        if (distance < 3f)
        {
            animator.SetTrigger(AnimatorValues.isShooting);
        }
 
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger(AnimatorValues.isShooting);
        foreach (var p in animator.parameters)
        {
            if (p.type == AnimatorControllerParameterType.Trigger)
            {
                animator.ResetTrigger(AnimatorValues.isShooting);
            }
        }
    }




            // OnStateMove is called right after Animator.OnAnimatorMove()
            //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
            //{
            //    // Implement code that processes and affects root motion
            //}

            // OnStateIK is called right after Animator.OnAnimatorIK()
            //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
            //{
            //    // Implement code that sets up animation IK (inverse kinematics)
            //}
        }
