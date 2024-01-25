using Photon.Pun;
using UnityEngine;

public class NotMaster : MonoBehaviourPunCallbacks
{
    private PhotonView view;

    void Start()
    {
        view = GetComponent<PhotonView>();
        if (view.IsMine)
        {
            GetComponent<Canvas>().enabled = true;
        }
        else
        {
            GetComponent<Canvas>().enabled = false;
        }
    }
}
