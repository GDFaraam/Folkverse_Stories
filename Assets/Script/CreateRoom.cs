using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Firebase.Database;

public class CreateRoom : MonoBehaviourPunCallbacks
{
    public InputField createInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void createRoom()
    {
        string roomName = "Room: " + createInput.text;

        PlayerPrefs.SetString("currentRoomID", createInput.text);

        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;

        string userID = PlayerPrefs.GetString("userID"); 

        DatabaseReference userReference = reference.Child("users").Child(userID);

        DatabaseReference roomsReference = userReference.Child("roomsCreated");

        DatabaseReference roomNodeReference = roomsReference.Child(roomName);

        DatabaseReference playersReference = roomNodeReference.Child("Players Joined");

        DatabaseReference attendanceReference = roomNodeReference.Child("Recorded Attendance");

        string playerName = PlayerPrefs.GetString("PlayerNickname");
        playersReference.Child("Teacher: " + userID).Child("name").SetValueAsync(playerName);
        attendanceReference.Child("Teacher: " + userID).Child("name").SetValueAsync(playerName);

        PhotonNetwork.CreateRoom(createInput.text);
    }


    public override void OnJoinedRoom()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.LoadLevel("Lobby World Map");
        }
    }
}
