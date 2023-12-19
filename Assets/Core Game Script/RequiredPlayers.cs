using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using TMPro;

public class RequiredPlayers : MonoBehaviour
{
    public int requiredCount;
    public int totalPlayerCount;
    private PhotonView view;
    public TextMeshProUGUI malakasAtMComponent;

    public GameObject[] indicators;
    private bool isMAMRunning = false;

    public PlayerRole playerRole;
    public InteractStone interactStone;

    void Start()
    {
        GameObject teacher = GameObject.FindWithTag("Teacher");
        playerRole = teacher.gameObject.GetComponent<PlayerRole>();
        interactStone = teacher.gameObject.GetComponent<InteractStone>();
        foreach (GameObject indicatorsGo in indicators){
            indicatorsGo.SetActive(false);
        }
        isMAMRunning = false;
        view = this.gameObject.GetComponent<PhotonView>();
    }

    void Update(){
        totalPlayerCount = PhotonNetwork.CurrentRoom.PlayerCount;
        malakasAtMComponent.text = $"{requiredCount} / {totalPlayerCount} players are required to start";
        if (requiredCount == totalPlayerCount){
            if (indicators[0].activeSelf && !isMAMRunning){
            RunMalakasAtM();
            isMAMRunning = true;
            }
        }
    }


    public void RunMalakasAtM(){
        if (view.IsMine && playerRole.role == "Teacher")
        {
            view.RPC("NextScenePun", RpcTarget.All);
        }
    }

    public void RunAlamatNgP(){
        if (view.IsMine && playerRole.role == "Teacher")
        {
            view.RPC("ANPCut", RpcTarget.All);
        }
    }

    [PunRPC]
     void ANPcut()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.LoadLevel(12);
    }

    [PunRPC]
     void NextScenePun()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        PhotonNetwork.LoadLevel(nextSceneIndex);
        requiredCount = 0;
    }
}
