using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidePanel : MonoBehaviour
{
    public GameObject Panel;

    public void HidePanelButton(){
        UISound.Instance.UIOpen();
        Panel.SetActive(false);
    }
    
    public void ShowPanelButton(){
        UISound.Instance.UIOpen();
        Panel.SetActive(true);
    }
}
