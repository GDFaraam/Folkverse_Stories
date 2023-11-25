using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

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
