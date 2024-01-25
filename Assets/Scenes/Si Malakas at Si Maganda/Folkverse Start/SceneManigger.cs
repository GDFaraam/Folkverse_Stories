using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;
using Photon.Pun;

public class SceneManigger : MonoBehaviourPunCallbacks
{
    public PlayableDirector[] cutscene;
    public GameObject[] sceneObjects;
    public Button[] buttons;

    public TextMeshProUGUI textComponent;
    public TextMeshProUGUI waitForSync;
    public string[] lines;
    public float textSpeed;
    public int index;

    private PhotonView view;
    private PlayerRole playerRole;

    public int syncDialogueCount;
    public int totalPlayerSynced;
    

    void Start(){
        AudioController.ACinstance.PlayAudioClip(2);
        view = this.gameObject.GetComponent<PhotonView>();
        GameObject teacher = GameObject.FindWithTag("Teacher");
        playerRole = teacher.gameObject.GetComponent<PlayerRole>();
        sceneObjects[0].SetActive(false);
        sceneObjects[2].SetActive(false);
        sceneObjects[3].SetActive(false);
        sceneObjects[4].SetActive(false);
        sceneObjects[5].SetActive(false);
        index = 0;
        StartCoroutine(DialogueShow());
    }

    IEnumerator DialogueShow(){
        yield return new WaitForSeconds(2f);
        ShowDialogue();
    }

    public void ShowDialogue(){
        textComponent.text = string.Empty;
        sceneObjects[0].SetActive(true);
        cutscene[1].Play();
        StartCoroutine(TypeLine());
    }

    public void HideDialogue(){
        sceneObjects[0].SetActive(false);
    }

    public void NextButtonAll()
    {
        if (view.IsMine && playerRole.role == "Teacher")
        {
            if (syncDialogueCount == totalPlayerSynced){
            view.RPC("NextButton", RpcTarget.All);
            }
            else if (syncDialogueCount > totalPlayerSynced){
            view.RPC("NextButton", RpcTarget.All);
            }
        }
    }

    void Update(){
        totalPlayerSynced = PhotonNetwork.CurrentRoom.PlayerCount;
        waitForSync.text = $"Waiting for everyone to finish the dialogue... {syncDialogueCount} / {totalPlayerSynced}";
        if (syncDialogueCount == totalPlayerSynced){
            buttons[0].interactable = true;
            sceneObjects[6].SetActive(true);
        }
        if (syncDialogueCount > totalPlayerSynced){
            buttons[0].interactable = true;
            sceneObjects[6].SetActive(true);
        }
    }


    [PunRPC]
    public void NextButton()
    {
        UISound.Instance.UIOpen();
        if (textComponent.text == lines[index])
            {
                if (textComponent.text == lines[0])
                {
                    HideDialogue();
                }
                else if (textComponent.text == lines[1])
                {
                    HideDialogue();
                    sceneObjects[2].SetActive(true);
                    sceneObjects[3].SetActive(true);
                    cutscene[2].Play();
                    StartCoroutine(NextDialogue());
                }
                else if (textComponent.text == lines[5])
                {
                    HideDialogue();
                    cutscene[3].Play();
                    StartCoroutine(NextScene());
                }
                else
                {
                    index++;
                    textComponent.text = string.Empty;
                    StartCoroutine(TypeLine());
                }
            }

        if (index == 0)
            {
                cutscene[0].Play();
                StartCoroutine(NextDialogue());
            }

        syncDialogueCount = 0;
    }

    IEnumerator TypeLine(){
        buttons[0].interactable = false;
        sceneObjects[6].SetActive(false);
        foreach (char c in lines[index].ToCharArray()){
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        EnableButton();
    }

    public void EnableButton(){
        view.RPC("AddSyncedPlayer", RpcTarget.All);
    }

    [PunRPC]
    public void AddSyncedPlayer(){
        syncDialogueCount++;
    }

    IEnumerator NextDialogue(){
        yield return new WaitForSeconds(6f);
        index++;
        ShowDialogue();
    }
    
    IEnumerator NextScene(){
        yield return new WaitForSeconds(9f);
        SceneManager.LoadScene(3);
    }
}
