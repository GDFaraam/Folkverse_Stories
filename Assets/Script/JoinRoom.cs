using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;
using Photon.Realtime;


public class JoinRoom : MonoBehaviourPunCallbacks
{
    public InputField joinInput;
    public TextMeshProUGUI textComponent;

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

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("Join Room Failed: " + message);

        if (returnCode == ErrorCode.GameDoesNotExist)
        {
            textComponent.text = "Room doesn't exist!";
        }
        else
        {
            textComponent.text = "Room is locked!";
        }

        StartCoroutine(WriteNothing());
    }

    IEnumerator WriteNothing()
    {
        yield return new WaitForSeconds(3f);
        textComponent.text = "";
    }
}
