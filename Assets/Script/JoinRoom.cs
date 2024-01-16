using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class JoinRoom : MonoBehaviourPunCallbacks
{

    public InputField joinInput;

    public void joinRoom()
    {
        PlayerPrefs.SetString("currentRoomID", joinInput.text);
        string nickname = PlayerPrefs.GetString("PlayerNickname");
        PhotonNetwork.LocalPlayer.NickName = nickname;
        PhotonNetwork.JoinRoom(joinInput.text);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Lobby World Map");
    }
}
