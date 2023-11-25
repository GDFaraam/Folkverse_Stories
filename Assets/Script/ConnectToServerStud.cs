using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class ConnectToServerStud : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();  
    }

    public override void OnJoinedLobby()
    {
        SceneManager.LoadScene("MAIN MENU STUDENT");
        Debug.Log("Joined");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
