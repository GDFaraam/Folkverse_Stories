using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using Photon.Pun;

public class Attendance : MonoBehaviourPunCallbacks
{
    private DatabaseReference reference;

    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        string newPlayerNickname = newPlayer.NickName;

        string roomName = "Room: " + PlayerPrefs.GetString("currentRoomID");

        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;

        string userID = PlayerPrefs.GetString("userID");

        DatabaseReference userReference = reference.Child("users").Child(userID);

        DatabaseReference roomsReference = userReference.Child("roomsCreated");

        DatabaseReference roomNodeReference = roomsReference.Child(roomName);

        DatabaseReference playersReference = roomNodeReference.Child("Players Joined");

        string playerName = newPlayerNickname;

        playersReference.Child(playerName).Child("name").SetValueAsync(playerName);
        playersReference.Child(playerName).Child("score").SetValueAsync("test score");
    }
}
