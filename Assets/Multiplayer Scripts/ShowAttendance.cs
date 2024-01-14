using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAttendance : MonoBehaviour
{
    public GameObject Panel;

    void Start(){
        Panel.SetActive(false);
    }

    public void ShowPanel(){
        Panel.SetActive(true);
    }
    
    public void HidePanel(){
        Panel.SetActive(false);
    }
}
