using Photon.Pun;

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
    }
}
