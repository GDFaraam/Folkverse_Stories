using UnityEngine;
using TMPro;
using Photon.Pun;

public class TeacherName : MonoBehaviourPunCallbacks, IPunInstantiateMagicCallback
{
    private TextMeshProUGUI nicknameGame;

    void Start()
    {
        nicknameGame = GetComponent<TextMeshProUGUI>();
        
        Debug.Log("current Nickname is: " + photonView.Owner.NickName);

        if (photonView.IsMine)
        {
            SetPlayerNickname(PhotonNetwork.LocalPlayer.NickName);
        }
        else
        {
            SetPlayerNickname(photonView.Owner.NickName);
        }
    }

    public void OnPhotonInstantiate(PhotonMessageInfo info)
    {
        if (!photonView.IsMine)
        {
            SetPlayerNickname(photonView.Owner.NickName);
        }
    }

    [PunRPC]
    void SetPlayerNickname(string newNickname)
    {
        nicknameGame.text = "Teacher: " + newNickname;
    }
}
