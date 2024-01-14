using Photon.Pun;
using UnityEngine;

public class PlayerRole : MonoBehaviourPunCallbacks
{
    public string role;

    private void Start()
    {
        if (photonView.IsMine)
        {
            // Set the role as a custom property for the local player
            photonView.Owner.SetCustomProperties(new ExitGames.Client.Photon.Hashtable
            {
                { "Role", role }
            });
        }
        Debug.Log("Role is: " + role);
        Debug.Log("Player count: " + PhotonNetwork.PlayerList.Length);
        Debug.Log("Room name: " + PhotonNetwork.CurrentRoom.Name);
    }
}
