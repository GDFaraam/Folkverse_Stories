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
        animator.speed = 0;
    }

    public void EnableAnimator(){
        animator.speed = 1;
    }
}
