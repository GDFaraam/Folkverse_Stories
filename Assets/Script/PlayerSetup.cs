using Photon.Pun;
using UnityEngine;

public class PlayerSetup : MonoBehaviourPunCallbacks
{
    void Start()
    {
        if (photonView.IsMine)
        {
            // Set the player's role
            string role = DeterminePlayerRole(); // Implement your logic to determine the player's role
            photonView.Owner.SetCustomProperties(new ExitGames.Client.Photon.Hashtable() { { "Role", role } });
        }
    }

    // Implement your logic to determine the player's role
    string DeterminePlayerRole()
    {
        // Your logic to determine if the player is a teacher or student
        // For example, based on a tag or some other condition

        // Placeholder logic:
        if (this.gameObject.CompareTag("Teacher"))
        {
            return "Teacher";
        }
        else
        {
            return "Student";
        }
    }
}
