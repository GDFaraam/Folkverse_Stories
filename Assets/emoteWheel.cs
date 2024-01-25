using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emoteWheel : MonoBehaviour
{

    public Animator Em;
    public bool EmOn;
    public GameObject Wheel;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Dance()
    {
        UISound.Instance.UIOpen();
        Em.SetTrigger("dance");
    }

    public void swipe()
    {
        UISound.Instance.UIOpen();
        Em.SetTrigger("swipe");
    }

    public void sideswipe()
    {
        UISound.Instance.UIOpen();
        Em.SetTrigger("sideswipe");
    }

    public void flop()
    {
        UISound.Instance.UIOpen();
        Em.SetTrigger("flop");
    }

    public void emoteWheelOn()
    {
        UISound.Instance.UIOpen();
        Wheel.gameObject.SetActive(true);
    }

    public void emoteWheelOff()
    {
        UISound.Instance.UIOpen();
        Wheel.gameObject.SetActive(false);
    }


}
