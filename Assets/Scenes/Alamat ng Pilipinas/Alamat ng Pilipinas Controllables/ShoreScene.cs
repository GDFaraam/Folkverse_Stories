using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using UnityEngine.UI;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class ShoreScene : MonoBehaviour
{
    public PlayableDirector[] cutscene;
    public GameObject[] storyScenes;
    public GameObject[] characters;
    public GameObject[] sceneObjects;
    public Button[] buttons;

    public GameObject diaBox;
    
    public TextMeshProUGUI textComponent;
    public string[] lines;
    private float textSpeed = 0.01f;
    public int index;

    private static ShoreScene SHOREinstance;
    private PhotonView view;
    private PlayerRole playerRole;

    public int syncDialogueCount;
    public int totalPlayerSynced;
    public TextMeshProUGUI waitForSync;

    private void Awake()
    {
        if (SHOREinstance == null)
        {

            SHOREinstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (SHOREinstance != this) {
        
        Destroy(SHOREinstance.gameObject);

        SHOREinstance = this;

        DontDestroyOnLoad(gameObject);

        }
    }

    void Start(){
        view = this.GetComponent<PhotonView>();
        GameObject teacher = GameObject.FindWithTag("Teacher");
        playerRole = teacher.gameObject.GetComponent<PlayerRole>();
        if (index == 5){
            diaBox.SetActive(false);
            StartCoroutine(DialogueShow());
            cutscene[5].Play();
        }
        else{
        storyScenes[0].SetActive(true);
        cutscene[0].Play();
        diaBox.SetActive(false);
        StartCoroutine(DialogueShow());
        }
    }

    void Update(){
        totalPlayerSynced = PhotonNetwork.CurrentRoom.PlayerCount;
        waitForSync.text = $"Waiting for everyone to finish the dialogue... {syncDialogueCount} / {totalPlayerSynced}";
        if (syncDialogueCount == totalPlayerSynced){
            buttons[0].interactable = true;
            sceneObjects[1].SetActive(true);
        }
        if (syncDialogueCount > totalPlayerSynced){
            buttons[0].interactable = true;
            sceneObjects[1].SetActive(true);
        }
    }

    IEnumerator DialogueShow(){
        yield return new WaitForSeconds(3f);
        ShowDialogue();
    }

    public void ShowDialogue(){
        textComponent.text = string.Empty;
        diaBox.SetActive(true);
        StartCoroutine(TypeLine());
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

    [PunRPC]
    public void NextButton(){
        if (index == 0){
            textComponent.text = string.Empty;
            index++;
            StartCoroutine(NextLine(5f));
            HideDialogue();
            cutscene[1].Play();
        }

        else if (index == 1){
            textComponent.text = string.Empty;
            HideDialogue();
            index++;
            StartCoroutine(NextLine(2f));
            cutscene[2].Play();
        }

        else if (index == 2){
            textComponent.text = string.Empty;
            index++;
            StartCoroutine(TypeLine());
        }
        else if (index == 3){
            textComponent.text = string.Empty;
            HideDialogue();
            cutscene[3].Play();
            index++;
            StartCoroutine(NextLine(6f));
        }
        else if (index == 4){
            textComponent.text = string.Empty;
            HideDialogue();
            cutscene[4].Play();
            if (view.IsMine && playerRole.role == "Teacher")
            {
                view.RPC("BackToIsland", RpcTarget.All);
            }
        }

        syncDialogueCount = 0;
    }

    public void SaveIndex(int newIndex)
        {
            PlayerPrefs.SetInt("SavedIndex", newIndex);
            PlayerPrefs.Save();
        }

    IEnumerator NextLine(float duration){
        yield return new WaitForSeconds(duration);
        ShowDialogue();
    }

    IEnumerator TypeLine(){
        sceneObjects[1].SetActive(false);
        buttons[0].interactable = false;
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

    [PunRPC]
    public void BackToIsland(){
        StartCoroutine(RescueScene());
    }

    IEnumerator RescueScene(){
        yield return new WaitForSeconds(2f);
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.LoadLevel(12);
    }

    public void HideDialogue(){
        diaBox.SetActive(false);
    }

    public void CaveScene(){
        sceneObjects[0].SetActive(false);
        storyScenes[0].SetActive(false);
        storyScenes[2].SetActive(true);
        cutscene[1].Play();
        buttons[1].gameObject.SetActive(false);
        characters[0].SetActive(true);
        StartCoroutine(DialogueShow());
    }
}
