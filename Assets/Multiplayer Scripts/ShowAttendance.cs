using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAttendance : MonoBehaviour
{
    public GameObject Panel;

    public void ShowPanel(){
        UISound.Instance.UIOpen();
        Panel.SetActive(true);
    }
    
    public void HidePanel(){
        UISound.Instance.UIOpen();
        Panel.SetActive(false);
    }
}
