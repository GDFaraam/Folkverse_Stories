using Photon.Pun;
using UnityEngine;

public class PlayerVisibility : MonoBehaviourPunCallbacks, IPunObservable
{
    [SerializeField]
    public string role; // Expose the role as a public field

    private SpriteRenderer spriteRenderer;
    private PlayerMovement playerMovement;

    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        playerMovement = GetComponent<PlayerMovement>();

        if (photonView.IsMine)
        {
            // Set the role as a custom property for the local player
            photonView.Owner.SetCustomProperties(new ExitGames.Client.Photon.Hashtable
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
            // Send data to others (including role information)
            stream.SendNext(photonView.Owner.CustomProperties["Role"]);
        }
        else
        {
            // Receive data (including role information)
            string receivedRole = (string)stream.ReceiveNext();
            photonView.Owner.SetCustomProperties(new ExitGames.Client.Photon.Hashtable
            {
                { "Role", receivedRole }
            });
            UpdateVisibility();
        }
    }

    void UpdateVisibility()
    {
        string role = (string)photonView.Owner.CustomProperties["Role"];

        // Enable rendering and interactions for all players if it's the teacher (local or remote)
        if (role == "Teacher")
        {
            EnableVisibility();
        }
        // Enable rendering and interactions for themselves and the teacher for students (local)
        else if (role == "Student" && photonView.IsMine)
        {
            EnableVisibility();
        }
        // Disable rendering and interactions for students (remote)
        else if (role == "Student" && !photonView.IsMine)
        {
            DisableVisibility();
        }
    }

    private void EnableVisibility()
    {
        // Enable rendering and interactions for all players
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
        // Disable rendering and interactions for students if it's not the local player
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
