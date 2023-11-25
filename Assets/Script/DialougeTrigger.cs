using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialougeTrigger : MonoBehaviour
{

    public Dialouge dialouge;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerDialouge ()
    {
        FindObjectOfType<dialougeManager>().StartDialouge(dialouge);
    }
}
