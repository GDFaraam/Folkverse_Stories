using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KickMute : MonoBehaviourPunCallbacks
{
    private PhotonView view;

    private bool micOn = true;
    private bool allMicOn = true;

    public static KickMute instance;

    private void Awake()
    {
        if (instance == null)
        {

            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this) {
            Destroy(instance.gameObject);
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        view = GetComponent<PhotonView>();
    }

    public void Mute(string targetPlayerNickname)
    {
        Debug.Log("Target Player Nickname: " + targetPlayerNickname);

        foreach (var player in PhotonNetwork.CurrentRoom.Players.Values)
        {
            if (player.NickName == targetPlayerNickname)
            {
                view.RPC("MutePlayer", player);
                Debug.Log("Target Owner: " + player);
                return; // Exit the loop once you find the matching player
            }
        }

        Debug.LogError("Target player not found.");
    }

    public void Kick(string targetPlayerNickname)
    {
        Debug.Log("Target Player Nickname: " + targetPlayerNickname);

        foreach (var player in PhotonNetwork.CurrentRoom.Players.Values)
        {
            if (player.NickName == targetPlayerNickname)
            {
                view.RPC("KickPlayer", player);
                Debug.Log("Target Owner: " + player);
                return; // Exit the loop once you find the matching player
            }
        }

        Debug.LogError("Target player not found.");
    }


    public void KickAll(){
        view.RPC("KickPlayer", RpcTarget.All);
    }

    public void MuteStudents(){
        view.RPC("MuteAllPlayer", RpcTarget.Others);
    }

    [PunRPC]
    public void MutePlayer()
    {
        GameObject mic = GameObject.FindWithTag("Mic");

        if (mic != null && micOn)
        {
            mic.GetComponent<Button>().interactable = false;
            mic.GetComponent<PushToTalkButton>().enabled = false;
            micOn = false;
        }
        else if (mic != null && !micOn){
            mic.GetComponent<Button>().interactable = true;
            mic.GetComponent<PushToTalkButton>().enabled = true;
            micOn = true;
        }
    }

    [PunRPC]
    public void MuteAllPlayer()
    {
        GameObject mic = GameObject.FindWithTag("Mic");

        if (mic != null && allMicOn)
        {
            mic.GetComponent<Button>().interactable = false;
            mic.GetComponent<PushToTalkButton>().enabled = false;
            allMicOn = false;
        }
        else if (mic != null && !allMicOn){
            mic.GetComponent<Button>().interactable = true;
            mic.GetComponent<PushToTalkButton>().enabled = true;
            allMicOn = true;
        }
    }

    [PunRPC]
    public void KickPlayer(){
        Debug.Log("KickPlayer RPC executed");
        GameObject quitObject = GameObject.FindWithTag("QuitComponent");
        GetQuitComponent quitCommand = quitObject.GetComponent<GetQuitComponent>();
        quitCommand.Quit(); 
    }

}
