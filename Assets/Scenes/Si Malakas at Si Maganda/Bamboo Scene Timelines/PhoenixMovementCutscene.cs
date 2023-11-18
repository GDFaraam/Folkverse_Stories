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
        characterAnimator = GetComponent<Animator>(); // Get the Animator component of the GameObject.
        lastPosition = transform.position;
    }

    void Update()
    {
        Vector3 currentPosition = transform.position;

        // Calculate the movement direction based on the change in position.
        Vector3 movementDirection = currentPosition - lastPosition;

        // Determine if the movement is primarily vertical.
        bool isVerticalMovement = Mathf.Abs(movementDirection.y) > Mathf.Abs(movementDirection.x);

        // Set the animator parameters based on the movement direction.
        characterAnimator.SetBool("isUp", isVerticalMovement && movementDirection.y > 0);
        characterAnimator.SetBool("isDown", isVerticalMovement && movementDirection.y < 0);
        characterAnimator.SetBool("isLeft", !isVerticalMovement && movementDirection.x < 0);
        characterAnimator.SetBool("isRight", !isVerticalMovement && movementDirection.x > 0);

        characterAnimatorShadow.SetBool("isUp", isVerticalMovement && movementDirection.y > 0);
        characterAnimatorShadow.SetBool("isDown", isVerticalMovement && movementDirection.y < 0);
        characterAnimatorShadow.SetBool("isLeft", !isVerticalMovement && movementDirection.x < 0);
        characterAnimatorShadow.SetBool("isRight", !isVerticalMovement && movementDirection.x > 0);

        // Update the last position for the next frame.
        lastPosition = currentPosition;
    }
}
