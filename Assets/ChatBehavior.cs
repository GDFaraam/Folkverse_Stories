using System.Collections;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class ChatBehavior : MonoBehaviourPun
{
    public GameObject chatTextPrefab;
    public GameObject chatTextPrefabMaster;

    public void SendChat(string playerName, string messageInput)
    {
        photonView.RPC("InstantiateChat", RpcTarget.AllBuffered, playerName, messageInput);
    }

    public void SendChatMaster(string playerName, string messageInput)
    {
        photonView.RPC("InstantiateChatMaster", RpcTarget.AllBuffered, playerName, messageInput);
    }

    [PunRPC]
    public void InstantiateChat(string playerName, string messageText, PhotonMessageInfo info)
    {
        ContentScript contentScript = GameObject.FindWithTag("ChatContent").GetComponent<ContentScript>();
        if (contentScript != null && contentScript.contentObject != null)
        {
            GameObject newChatText = Instantiate(chatTextPrefab, contentScript.contentObject.transform);
            TextMeshProUGUI[] textComponents = newChatText.GetComponentsInChildren<TextMeshProUGUI>();

            if (textComponents.Length >= 2)
            {
                textComponents[0].text = playerName;
                textComponents[1].text = messageText;
            }
            else
            {
                Debug.LogError("Prefab structure doesn't match expectations. Make sure you have TextMeshProUGUI components on the prefab.");
            }
        }
        else
        {
            Debug.LogError("ContentScript or contentObject not found or not assigned.");
        }
    }

    [PunRPC]
    public void InstantiateChatMaster(string playerName, string messageText, PhotonMessageInfo info)
    {
        ContentScript contentScript = GameObject.FindWithTag("ChatContent").GetComponent<ContentScript>();
        if (contentScript != null && contentScript.contentObject != null)
        {
            GameObject newChatText = Instantiate(chatTextPrefabMaster, contentScript.contentObject.transform);
            TextMeshProUGUI[] textComponents = newChatText.GetComponentsInChildren<TextMeshProUGUI>();

            if (textComponents.Length >= 2)
            {
                textComponents[0].text = playerName;
                textComponents[1].text = messageText;
            }
            else
            {
                Debug.LogError("Prefab structure doesn't match expectations. Make sure you have TextMeshProUGUI components on the prefab.");
            }
        }
        else
        {
            Debug.LogError("ContentScript or contentObject not found or not assigned.");
        }
    }
}
