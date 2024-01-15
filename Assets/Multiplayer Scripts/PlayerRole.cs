using Photon.Pun;
using UnityEngine;

public class PlayerRole : MonoBehaviour
{
    public string role;
    public PhotonView view;

    private void Start()
    {
        view = GetComponent<PhotonView>();
        if (view.IsMine)
        {
            // Set the role as a custom property for the local player
            view.Owner.SetCustomProperties(new ExitGames.Client.Photon.Hashtable
            {
                { "Role", role }
            });
        }
        Debug.Log("Role is: " + role);
        Debug.Log("Player count: " + PhotonNetwork.PlayerList.Length);
        Debug.Log("Room name: " + PhotonNetwork.CurrentRoom.Name);
    }
}
