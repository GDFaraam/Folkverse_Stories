using Photon.Pun;
using UnityEngine;

public class PlayerRole : MonoBehaviourPunCallbacks
{
    public string role;
    private PhotonView view;

    private void Start()
    {
        view = GetComponent<PhotonView>();

        if (view != null && view.IsMine)
        {
            ExitGames.Client.Photon.Hashtable customProperties = new ExitGames.Client.Photon.Hashtable();
            customProperties.Add("Role", role);
            PhotonNetwork.LocalPlayer.SetCustomProperties(customProperties);
        }

        Debug.Log("Role is: " + role);
        Debug.Log("Player count: " + PhotonNetwork.PlayerList.Length);
        Debug.Log("Room name: " + PhotonNetwork.CurrentRoom.Name);
    }
}
