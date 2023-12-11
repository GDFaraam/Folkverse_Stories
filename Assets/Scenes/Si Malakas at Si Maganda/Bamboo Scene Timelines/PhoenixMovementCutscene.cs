using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoenixMovementCutscene : MonoBehaviour
{
    private Animator characterAnimator;
    public Animator characterAnimatorShadow;
    private Vector3 lastPosition;

    void Start()
    {
        characterAnimator = GetComponent<Animator>(); 
        lastPosition = transform.position;
    }

    void Update()
    {
        Vector3 currentPosition = transform.position;

        bool isIdle = currentPosition == lastPosition;

        Vector3 movementDirection = currentPosition - lastPosition;

        bool isVerticalMovement = Mathf.Abs(movementDirection.y) > Mathf.Abs(movementDirection.x);

        characterAnimator.SetBool("isUp", isVerticalMovement && movementDirection.y > 0);
        characterAnimator.SetBool("isDown", isVerticalMovement && movementDirection.y < 0);
        characterAnimator.SetBool("isLeft", !isVerticalMovement && movementDirection.x < 0);
        characterAnimator.SetBool("isRight", !isVerticalMovement && movementDirection.x > 0);
        characterAnimator.SetBool("isIdle", isIdle);

        characterAnimatorShadow.SetBool("isUp", isVerticalMovement && movementDirection.y > 0);
        characterAnimatorShadow.SetBool("isDown", isVerticalMovement && movementDirection.y < 0);
        characterAnimatorShadow.SetBool("isLeft", !isVerticalMovement && movementDirection.x < 0);
        characterAnimatorShadow.SetBool("isRight", !isVerticalMovement && movementDirection.x > 0);
        characterAnimatorShadow.SetBool("isIdle", isIdle);

        lastPosition = currentPosition;
    }
}
