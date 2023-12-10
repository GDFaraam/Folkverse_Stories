using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAnimationShake : MonoBehaviour
{
    private Animator animator;

    void Start(){
        animator = GetComponent<Animator>();
    }

    public void StopAnimation(){
        animator.SetBool("notShaking", true);
    }
}
