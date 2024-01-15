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

    public string teacherSceneName;
    public string studentSceneName;

    void Start()
    {
        view = GetComponent<PhotonView>();
        DontDestroyOnLoad(gameObject);
    }

    public void Mute(int targetPlayerID)
    {
        Debug.Log("Target Player ID: " + targetPlayerID);

        if (PhotonNetwork.CurrentRoom.Players.TryGetValue(targetPlayerID, out Photon.Realtime.Player targetPlayer))
        {
            Debug.Log("Target Player ID: " + targetPlayerID);
            view.RPC("MutePlayer", targetPlayer);
            Debug.Log("Target Owner: " + targetPlayer);
        }
        else
        {
            Debug.LogError("Target player not found.");
        }
    }

    public void MuteStudents(){
        view.RPC("MuteAllPlayer", RpcTarget.Others);
    }

    public void Kick(int targetPlayerID)
    {
        Debug.Log("Target Player ID: " + targetPlayerID);

        if (PhotonNetwork.CurrentRoom.Players.TryGetValue(targetPlayerID, out Photon.Realtime.Player targetPlayer))
        {
            Debug.Log("Target Player ID: " + targetPlayerID);
            view.RPC("KickPlayer", targetPlayer);
            Debug.Log("Target Owner: " + targetPlayer);
        }
        else
        {
            Debug.LogError("Target player not found.");
        }
    }

    public void KickAll(){
        view.RPC("KickPlayer", RpcTarget.All    );
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
        LeaveRoomAndLoadScene();
    }

    public override void OnLeftRoom()
    {
        LoadSceneBasedOnRole();
    }

    public void LeaveRoomAndLoadScene()
    {
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.Disconnect();
    }

    void LoadSceneBasedOnRole()
    {
        Debug.Log("LoadSceneBasedRole");
        
        if (PhotonNetwork.LocalPlayer != null && PhotonNetwork.LocalPlayer.IsMasterClient)
        {
            Debug.Log("Local player is the master client");
            SceneManager.LoadScene(teacherSceneName);
            Debug.Log("Successfully moved to teacher scene");
        }
        else
        {
            Debug.Log("Local player is not the master client");
            SceneManager.LoadScene(studentSceneName);
            Debug.Log("Successfully moved to student scene");
        }
    }


}
