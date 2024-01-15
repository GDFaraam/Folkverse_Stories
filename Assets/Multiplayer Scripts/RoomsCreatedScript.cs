using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoomsCreatedScript : MonoBehaviour
{
    private GameObject roomsCreatedPanel;
    public TextMeshProUGUI buttonName;
    private AttendanceMonitoringScript attendanceScript;

    void Start(){
        GameObject roomPanel = GameObject.FindWithTag("CreatedRooms");
        roomsCreatedPanel = roomPanel;
        GameObject attendanceObject = GameObject.FindWithTag("AttendanceBehavior");
        attendanceScript = attendanceObject.GetComponent<AttendanceMonitoringScript>();
    }
    
    public void ThisButtonPressed(){
        PlayerPrefs.SetString("ChosenRoom", buttonName.text);
        roomsCreatedPanel.SetActive(false);
        attendanceScript.GoToChooseButton();
    }
}
