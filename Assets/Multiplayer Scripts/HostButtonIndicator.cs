using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class HostButtonIndicator : MonoBehaviourPunCallbacks
{
    void Start()
    {
        Image image = GetComponent<Image>();

        if (PhotonNetwork.IsMasterClient)
        {
            // Set the alpha channel to 1 (fully opaque) if the player is the master client
            ChangeImageOpacity(image, 1f);
        }
        else
        {
            // Set the alpha channel to 0 (fully transparent) if the player is not the master client
            ChangeImageOpacity(image, 0f);
        }
    }

    void ChangeImageOpacity(Image image, float alpha)
    {
        Color imageColor = image.color;
        imageColor.a = alpha;
        image.color = imageColor;
    }
}
