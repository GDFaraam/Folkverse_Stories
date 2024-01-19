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
        Em.SetTrigger("dance");
        
        
        
    }

    public void swipe()
    {
        Em.SetTrigger("swipe");
    }

    public void sideswipe()
    {
        Em.SetTrigger("flop");
    }

    public void flop()
    {
        Em.SetTrigger("sideswipe");
    }

    public void emoteWheelOn()
    {
        if(EmOn!=true)
        {
            EmOn = true;
            Wheel.gameObject.SetActive(EmOn);
        }
        else
        {
            EmOn = false;
            Wheel.gameObject.SetActive(EmOn);
        }
    }


}
