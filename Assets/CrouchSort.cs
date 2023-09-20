using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchSort : StateMachineBehaviour
{
    private SpriteRenderer[] spriteUpper;
    private SpriteRenderer[] spriteLower;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (spriteUpper == null){
            spriteUpper = animator.gameObject.GetComponent<GrassInteraction>().spriteUpper;
        }

        if (spriteLower == null){
            spriteLower = animator.gameObject.GetComponent<GrassInteraction>().spriteLower;
        }

        foreach (var SpritesUp in spriteUpper){
            SpritesUp.sortingOrder = 5;
        }
        foreach (var SpritesLow in spriteLower){
            SpritesLow.sortingOrder = 4;
        }
    }


    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        foreach (var SpritesUp in spriteUpper){
            SpritesUp.sortingOrder = 6;
        }
        foreach (var SpritesLow in spriteLower){
            SpritesLow.sortingOrder = 5;
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
