using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class InGamNickName : MonoBehaviourPunCallbacks
{
    private TextMeshProUGUI nicknameGame;

    void Start()
    {
        nicknameGame = GetComponent<TextMeshProUGUI>();

        UpdateNickname();
    }

    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)

    {
        UpdateNickname();
    }

    public override void OnPlayerPropertiesUpdate(Photon.Realtime.Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        if (changedProps.ContainsKey("NickName"))
        {
            UpdateNickname();
        }
    }

    void UpdateNickname()
    {
        if (photonView.IsMine)
        {
            nicknameGame.text = PhotonNetwork.LocalPlayer.NickName;
        }
        else
        {
            PhotonView parentPhotonView = transform.parent.GetComponent<PhotonView>();

            if (parentPhotonView != null && parentPhotonView.Owner.CustomProperties.ContainsKey("NickName"))
            {
                nicknameGame.text = (string)parentPhotonView.Owner.CustomProperties["NickName"];
            }
        }
    }
}
