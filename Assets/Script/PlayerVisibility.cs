using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerVisibility : MonoBehaviourPunCallbacks, IPunObservable
{
    [SerializeField]
    public string role;

    private SpriteRenderer spriteRenderer;
    private PlayerMovement playerMovement;

    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        playerMovement = GetComponent<PlayerMovement>();

        if (photonView.IsMine)
        {
            PhotonNetwork.LocalPlayer.SetCustomProperties(new ExitGames.Client.Photon.Hashtable
            {
                { "Role", role }
            });
        }

        UpdateVisibility();
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(PhotonNetwork.LocalPlayer.CustomProperties["Role"]);
        }
        else
        {
            string receivedRole = (string)stream.ReceiveNext();
            PhotonNetwork.LocalPlayer.SetCustomProperties(new ExitGames.Client.Photon.Hashtable
            {
                { "Role", receivedRole }
            });
            UpdateVisibility();
        }
    }

    void UpdateVisibility()
    {
        string localPlayerRole = (string)PhotonNetwork.LocalPlayer.CustomProperties["Role"];

        if (SceneManager.GetActiveScene().name == "Lobby World Map")
        {
            EnableVisibility();
        }
        else
        {
            if (localPlayerRole == "Teacher")
            {
                EnableVisibility();
            }
            else if (localPlayerRole == "Student" && photonView.IsMine)
            {
                EnableVisibility();
            }
            else if (localPlayerRole == "Student" && !photonView.IsMine)
            {
                DisableVisibility();
            }
        }
    }

    private void EnableVisibility()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.enabled = true;
        }

        if (playerMovement != null)
        {
            playerMovement.enabled = true;
        }
    }

    private void DisableVisibility()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.enabled = false;
        }

        if (playerMovement != null)
        {
            playerMovement.enabled = false;
        }
    }
}
