using Photon.Pun;
using UnityEngine;

public class NotMaster : MonoBehaviourPunCallbacks
{
    void Start()
    {
        // Check if the local player is not the master client
        if (!PhotonNetwork.IsMasterClient)
        {
            // Enable the Canvas for non-host players
            GetComponent<Canvas>().enabled = true;
        }
        else
        {
            // Disable the Canvas for the master client (host)
            GetComponent<Canvas>().enabled = false;
        }
    }
}
