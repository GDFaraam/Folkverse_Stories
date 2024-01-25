using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonComponent : MonoBehaviour
{
    // Start is called before the first frame update

    public InteractStone interactStone; 


    void Start()
    {
        interactStone = this.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<InteractStone>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Next()
    {
        UISound.Instance.UIOpen();
        interactStone.ToggleCount();
    }
}
