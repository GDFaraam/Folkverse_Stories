using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        string savedNickname = PlayerPrefs.GetString("PlayerNickname", "No_Name");
        PhotonNetwork.NickName = savedNickname;
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        SceneManager.LoadScene("MAIN MENU TEACHER");
        Debug.Log("Joined");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
