using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitConfirm : MonoBehaviour
{
    public GameObject quitObject;

    void Start(){
        quitObject.SetActive(false);
    }

    public void OpenPanel(){
        quitObject.SetActive(true);
    }

    public void ClosePanel(){
        quitObject.SetActive(false);
    }
}
