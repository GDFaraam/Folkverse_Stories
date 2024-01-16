using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoomDefiner : MonoBehaviour
{
    public TextMeshProUGUI thisText;

    void Start(){
        thisText = GetComponent<TextMeshProUGUI>();
        thisText.text = "Room: " + PlayerPrefs.GetString("currentRoomID");
    }
}
