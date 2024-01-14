using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class AttendanceSheet : MonoBehaviourPunCallbacks
{
    public GameObject playerInfoPrefab;
    public GameObject content;

    private Dictionary<int, GameObject> playerInfoObjects = new Dictionary<int, GameObject>();

    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        Debug.Log("Player entered room with Actor Number: " + newPlayer.ActorNumber);
        
        GameObject newPlayerInfo = Instantiate(playerInfoPrefab, content.transform);

        TextMeshProUGUI playerNameText = newPlayerInfo.GetComponent<TextMeshProUGUI>();
        KickMuteBehavior kickMuteBehavior = newPlayerInfo.GetComponent<KickMuteBehavior>();

        if (playerNameText != null)
        {
            playerNameText.text = newPlayer.NickName;
        }

        kickMuteBehavior.playerID = newPlayer.ActorNumber;
        playerInfoObjects[newPlayer.ActorNumber] = newPlayerInfo;
    }

    public override void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)
    {
        if (playerInfoObjects.ContainsKey(otherPlayer.ActorNumber))
        {
            Destroy(playerInfoObjects[otherPlayer.ActorNumber]);

            playerInfoObjects.Remove(otherPlayer.ActorNumber);
        }
    }
}
