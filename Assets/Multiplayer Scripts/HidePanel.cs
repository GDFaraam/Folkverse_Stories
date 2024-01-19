using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidePanel : MonoBehaviour
{
    public GameObject Panel;

    public void HidePanelButton(){
        Panel.SetActive(false);
    }

    public void ShowPanelButton(){
        Panel.SetActive(true);
    }
}
