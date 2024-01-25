using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class RequiredPlayers : MonoBehaviour
{
    public int requiredCount;
    public int totalPlayerCount;
    private PhotonView view;
    public TextMeshProUGUI[] textList;
    public TextMeshProUGUI[] countDownText;

    public GameObject[] indicators;
    private bool isMAMRunning = false;
    private bool isAMPRunning = false;

    public PlayerRole playerRole;
    public InteractStone interactStone;

    public GameObject storyRoomPosition;

    private const string IsLockedKey = "IsLocked";

    void Start()
    {
        GameObject teacher = GameObject.FindWithTag("Teacher");
        playerRole = teacher.gameObject.GetComponent<PlayerRole>();
        interactStone = teacher.gameObject.GetComponent<InteractStone>();
        foreach (GameObject indicatorsGo in indicators){
            indicatorsGo.SetActive(false);
        }
        isMAMRunning = false;
        isAMPRunning = false;
        view = this.gameObject.GetComponent<PhotonView>();
    }

    void Update(){
        totalPlayerCount = PhotonNetwork.CurrentRoom.PlayerCount;
        foreach (TextMeshProUGUI TextMeshAll in textList){
            if (TextMeshAll != null){
            TextMeshAll.text = $"{requiredCount} / {totalPlayerCount} players are required to start";
            }
        }
        if (requiredCount == totalPlayerCount){
            if (indicators[0].activeSelf && !isMAMRunning){
            RunMalakasAtM();
            isMAMRunning = true;
            }
            else if (indicators[1].activeSelf && !isAMPRunning){
            RunAlamatNgP();
            isAMPRunning = true;
            }
        }
    }

    public void StartTimer()
    {
        StartCoroutine(CountdownTimer());
    }

    private IEnumerator CountdownTimer()
    {
        float countdownTime = 120f;

        while (countdownTime > 0f)
        {
            yield return new WaitForSeconds(1f);
            countdownTime--;

            int minutes = Mathf.FloorToInt(countdownTime / 60f);
            int seconds = Mathf.FloorToInt(countdownTime % 60f);

            countDownText[0].text = "Minutes: " + minutes.ToString("D2") + " Seconds: " + seconds.ToString("D2");
        }

        RunMalakasAtM();
    }

    public void StartTimerANP()
    {
        StartCoroutine(CountdownTimerANP());
    }

    private IEnumerator CountdownTimerANP()
    {
        float countdownTime = 120f;

        while (countdownTime > 0f)
        {
            yield return new WaitForSeconds(1f);
            countdownTime--;

            int minutes = Mathf.FloorToInt(countdownTime / 60f);
            int seconds = Mathf.FloorToInt(countdownTime % 60f);

            countDownText[1].text = "Minutes: " + minutes.ToString("D2") + " Seconds: " + seconds.ToString("D2");
        }

        RunAlamatNgP();
    }

    public void RunMalakasAtM(){
        if (view.IsMine && playerRole.role == "Teacher")
        {
            LockRoom();
            view.RPC("NextScenePun", RpcTarget.All);
            interactStone.interactPedestal = false;
            interactStone.MalakasAtM = false;
        }
    }

    public void RunMalakasAtMOutro(){
        if (view.IsMine && playerRole.role == "Teacher")
        {
            view.RPC("MalakasOutro", RpcTarget.All);
        }
    }

    public void RunAlamatNgP(){
        if (view.IsMine && playerRole.role == "Teacher")
        {
            LockRoom();
            view.RPC("ANPcut", RpcTarget.All);
            interactStone.interactPedestal = false;
            interactStone.AlamatNgP = false;
        }
    }

    public void RunStoryRoom(){
        if (view.IsMine && playerRole.role == "Teacher")
        {
            LockRoom();
            view.RPC("StoryRoom", RpcTarget.All);
        }
    }

    [PunRPC]
    void ANPcut()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.LoadLevel(12);
        requiredCount = 0;
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

    [PunRPC]
    void StoryRoom()
    {
        GameObject teacherObject = GameObject.FindWithTag("Teacher");
        GameObject[] students = GameObject.FindGameObjectsWithTag("Player");
        teacherObject.transform.position = storyRoomPosition.transform.position;
        foreach (GameObject studentGo in students)
        {
            studentGo.transform.position = storyRoomPosition.transform.position;
        }
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.LoadLevel(9);
        requiredCount = 0;
    }

    [PunRPC]
    void MalakasOutro()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        PhotonNetwork.LoadLevel(nextSceneIndex);
        requiredCount = 0;
    }


    public void LockRoom()
    {
        PhotonNetwork.CurrentRoom.IsOpen = false;
        PhotonNetwork.CurrentRoom.IsVisible = false;
    }

    public void UnlockRoom()
    {
        PhotonNetwork.CurrentRoom.IsOpen = true;
        PhotonNetwork.CurrentRoom.IsVisible = true;
    }
}
