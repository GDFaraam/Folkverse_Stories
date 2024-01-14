using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class ButtonController : MonoBehaviour
{
    public Button myButton;

    private void Start()
    {
        // Check the user's role when the scene starts
        CheckUserRole();
    }

    private void CheckUserRole()
    {
        // Get the current player's properties
        if (PhotonNetwork.LocalPlayer.CustomProperties.TryGetValue("Role", out object roleObj))
        {
            // Check the role and disable the button if necessary
            string role = (string)roleObj;

            if (role == "Admin")
            {
                // Allow admins to interact with the button
                myButton.interactable = true;
            }
            else
            {
                // Disable the button for other roles
                myButton.interactable = false;
            }
        }
    }

    void Update()
    {
        CheckUserRole();
    }
}
