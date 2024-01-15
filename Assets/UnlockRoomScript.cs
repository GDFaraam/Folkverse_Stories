using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class UnlockRoomScript : MonoBehaviour
{
    public RequiredPlayers requiredPlayers;

    void Start()
    {
        // Unlock the room and register a callback to check the result
        requiredPlayers.UnlockRoom();
    }

    // Callback method for OnRoomPropertiesUpdate
    void OnRoomPropertiesUpdate(Hashtable propertiesThatChanged)
    {
        // Check the room's openness and visibility after the UnlockRoom operation
        Debug.Log("IsRoomLocked: " + PhotonNetwork.CurrentRoom.IsOpen);
        Debug.Log("IsRoomVisible: " + PhotonNetwork.CurrentRoom.IsVisible);
    }
}
