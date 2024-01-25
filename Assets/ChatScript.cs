using System.Collections;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class ChatScript : MonoBehaviourPun
{
    public TMP_InputField messageInput;
    public GameObject ChatPanel;

    public void SubmitChat()
    {
        if (PhotonNetwork.IsMasterClient){
        string playerName = PhotonNetwork.NickName;
        GameObject chatObject = GameObject.FindWithTag("ChatObject");
        ChatBehavior chatSend = chatObject.GetComponent<ChatBehavior>();
        chatSend.SendChatMaster(playerName, messageInput.text);
        messageInput.text = "";
        }
        
        else{
        string playerName = PhotonNetwork.NickName;
        GameObject chatObject = GameObject.FindWithTag("ChatObject");
        ChatBehavior chatSend = chatObject.GetComponent<ChatBehavior>();
        chatSend.SendChat(playerName, messageInput.text);
        messageInput.text = "";
        }
    }

    public void OpenChatPanel()
    {
        UISound.Instance.UIOpen();
        ChatPanel.SetActive(true);
    }

    public void CloseChatPanel()
    {
        UISound.Instance.UIOpen();
        ChatPanel.SetActive(false);
    }

}
