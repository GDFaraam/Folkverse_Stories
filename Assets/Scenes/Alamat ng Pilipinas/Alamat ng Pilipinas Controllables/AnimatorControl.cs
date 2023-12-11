using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorControl : MonoBehaviour
{
    private Animator animator;

    void Start(){
        animator = GetComponent<Animator>();
    }

    public void DisableAnimator(){
        animator.enabled = false;
    }

    public void EnableAnimator(){
        animator.enabled = true;
    }
}
