using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Idle : StateMachineBehaviour
{
    Transform player;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag(Tag.PLAYER).transform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float distance = Vector2.Distance(player.position, animator.transform.position);
        if (Vector2.Distance(animator.transform.position, player.position) <= 5f)
        {
            animator.SetBool(AnimatorValues.isWalking, true);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    
}
