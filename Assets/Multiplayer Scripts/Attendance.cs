using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using Photon.Pun;

public class Attendance : MonoBehaviourPunCallbacks
{
    private DatabaseReference reference;
    public static List<string> activePlayers = new List<string>();
    private KickMute dcAll;

    void Start(){
        GameObject QuitObject = GameObject.FindWithTag("KickMuteScript");
        dcAll = QuitObject.GetComponent<KickMute>();
        PhotonNetwork.AddCallbackTarget(this);
    }

    void OnDestroy()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
    }

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

        activePlayers.Add(playerName);
    }

    public override void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)
    {
        string leftPlayerNickname = otherPlayer.NickName;

        activePlayers.Remove(leftPlayerNickname);
    }

    public void RecordAttendance()
    {
        string roomName = "Room: " + PlayerPrefs.GetString("currentRoomID");

        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;

        string userID = PlayerPrefs.GetString("userID");

        DatabaseReference userReference = reference.Child("users").Child(userID);

        DatabaseReference roomsReference = userReference.Child("roomsCreated");

        DatabaseReference roomNodeReference = roomsReference.Child(roomName);

        DatabaseReference attendanceReference = roomNodeReference.Child("Recorded Attendance");

        foreach (string playerName in activePlayers)
        {
            attendanceReference.Child(playerName).Child("name").SetValueAsync(playerName);
        }
    }

    public override void OnMasterClientSwitched(Photon.Realtime.Player newMasterClient)
    {
        dcAll.KickAll();
    }
}
