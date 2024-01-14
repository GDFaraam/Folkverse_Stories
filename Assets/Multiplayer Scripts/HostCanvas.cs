using Photon.Pun;
using UnityEngine;

public class HostCanvas : MonoBehaviourPunCallbacks
{
    void Start()
    {
        // Check if the local player is the master client (host)
        if (PhotonNetwork.IsMasterClient)
        {
            // Enable the Canvas for the host
            GetComponent<Canvas>().enabled = true;
        }
        else
        {
            // Disable the Canvas for non-host players
            GetComponent<Canvas>().enabled = false;
        }
    }
}
