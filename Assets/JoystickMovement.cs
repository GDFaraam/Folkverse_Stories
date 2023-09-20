using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickMovement : MonoBehaviour
{
    public GameObject joystick;
    public GameObject joystickBG;
    public Vector2 joystickVec;
    private Vector2 joystickTouchPos;
    private Vector2 joystickOriginalPos;
    private float joystickRadius;
    public Animator characterAnimator;

    // Start is called before the first frame update
    void Start()
    {
        joystickOriginalPos = joystickBG.transform.position;
        joystickRadius = joystickBG.GetComponent<RectTransform>().sizeDelta.y / 4;
    }

    void Update(){

        float horizontalInput = joystickVec.x;
        float verticalInput = joystickVec.y;

        characterAnimator.SetBool("isUp", verticalInput > 0 && Mathf.Abs(verticalInput) > Mathf.Abs(horizontalInput));
        characterAnimator.SetBool("isDown", verticalInput < 0 && Mathf.Abs(verticalInput) > Mathf.Abs(horizontalInput));
        characterAnimator.SetBool("isLeft", horizontalInput < 0 && Mathf.Abs(horizontalInput) > Mathf.Abs(verticalInput));
        characterAnimator.SetBool("isRight", horizontalInput > 0 && Mathf.Abs(horizontalInput) > Mathf.Abs(verticalInput));

        characterAnimator.SetBool("isIdle", joystickVec == Vector2.zero);
    }

    public void Drag(BaseEventData baseEventData)
{
    PointerEventData pointerEventData = baseEventData as PointerEventData;
    Vector2 dragPos = pointerEventData.position;

    joystickVec = (dragPos - joystickOriginalPos).normalized;

    float joystickDist = Vector2.Distance(dragPos, joystickOriginalPos);

    if (joystickDist < joystickRadius)
    {
        joystick.transform.position = dragPos;
    }
    else
    {
        joystick.transform.position = joystickOriginalPos + joystickVec * joystickRadius;
    }

    joystickTouchPos = joystick.transform.position;
}



    public void PointerUp()
    {
        joystickVec = Vector2.zero;
        joystick.transform.position = joystickOriginalPos;
        joystickBG.transform.position = joystickOriginalPos;
    }
}
