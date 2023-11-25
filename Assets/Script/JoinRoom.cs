using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class JoinRoom : MonoBehaviourPunCallbacks
{

    public InputField joinInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void joinRoom()
    {
        PhotonNetwork.JoinRoom(joinInput.text);
    }


    public override void OnJoinedRoom()
    {

        PhotonNetwork.LoadLevel("Lobby World Map");
    }
}
