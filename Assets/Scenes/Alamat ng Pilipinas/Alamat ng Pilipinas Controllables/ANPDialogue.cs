using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using UnityEngine.UI;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class ANPDialogue : MonoBehaviour
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

    public static ANPDialogue instance;
    private PhotonView view;
    private PlayerRole playerRole;

    private bool rescueSceneDone = false;

    public int syncDialogueCount;
    public int totalPlayerSynced;
    public TextMeshProUGUI waitForSync;

    private void Awake()
    {
        if (instance == null)
        {

            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this) {
        
        Destroy(instance.gameObject);

        instance = this;
        index = 13;
        if(rescueSceneDone){
            index = 0;
        }

        DontDestroyOnLoad(gameObject);

        }
    }


    void Start(){
        view = this.GetComponent<PhotonView>();
        GameObject teacher = GameObject.FindWithTag("Teacher");
        playerRole = teacher.gameObject.GetComponent<PlayerRole>();
        if (index == 13){
            foreach (GameObject sceneGo in storyScenes){
            sceneGo.SetActive(false);
        }
        foreach (GameObject charactersGo in characters){
            charactersGo.SetActive(false);
        }
        diaBox.SetActive(false);
        buttons[1].gameObject.SetActive(false);
        storyScenes[2].SetActive(true);
        characters[0].SetActive(true);
        cutscene[7].Play();
        StartCoroutine(DialogueShow());
        rescueSceneDone = true;
        }

        else
        {
        foreach (GameObject sceneGo in storyScenes){
            sceneGo.SetActive(false);
        }
        foreach (GameObject charactersGo in characters){
            charactersGo.SetActive(false);
        }
        buttons[1].gameObject.SetActive(false);
        storyScenes[0].SetActive(true);
        diaBox.SetActive(false);
        cutscene[0].Play();
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

    public void SaveIndex(int newIndex)
    {
        PlayerPrefs.SetInt("SavedIndex", newIndex);
        PlayerPrefs.Save();
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
            StartCoroutine(NextLine(1.5f));
            HideDialogue();
        }

        else if (index == 1){
            textComponent.text = string.Empty;
            index++;
            StartCoroutine(TypeLine());
        }

        else if (index == 2){
            textComponent.text = string.Empty;
            HideDialogue();
            buttons[1].gameObject.SetActive(true);
            index++;
        }
        else if (index == 3){
            textComponent.text = string.Empty;
            HideDialogue();
            cutscene[2].Play();
            index++;
            StartCoroutine(NextLine(4f));
        }
        else if (index == 4){
            textComponent.text = string.Empty;
            HideDialogue();
            sceneObjects[0].SetActive(true);
            storyScenes[2].SetActive(false);
            characters[0].SetActive(false);
            storyScenes[1].SetActive(true);
            characters[1].SetActive(true);
            cutscene[3].Play();
            index++;
            StartCoroutine(NextLine(3f));
        }
        else if (index == 5){
            textComponent.text = string.Empty;
            HideDialogue();
            index++;
            StartCoroutine(NextLine(1f));
        }
        else if (index == 6){
            textComponent.text = string.Empty;
            index++;
            StartCoroutine(TypeLine());
        }
        else if (index == 7){
            textComponent.text = string.Empty;
            HideDialogue();
            index++;
            StartCoroutine(NextLine(2f));
        }
        else if (index == 8){
            textComponent.text = string.Empty;
            HideDialogue();
            cutscene[4].Play();
            index++;
            StartCoroutine(NextLine(7f));
        }
        else if (index == 9){
            textComponent.text = string.Empty;
            HideDialogue();
            cutscene[5].Play();
            index++;
            StartCoroutine(NextLine(3f));
        }
        else if (index == 10){
            textComponent.text = string.Empty;
            HideDialogue();
            storyScenes[2].SetActive(true);
            storyScenes[1].SetActive(false);
            characters[0].SetActive(true);
            characters[1].SetActive(false);
            cutscene[6].Play();
            index++;
            StartCoroutine(NextLine(14f));
        }
        else if (index == 11){
            textComponent.text = string.Empty;
            HideDialogue();
            index++;
            StartCoroutine(NextLine(6f));
        }
        else if (index == 12){
            index++;
            PhotonNetwork.AutomaticallySyncScene = true;
            PhotonNetwork.LoadLevel(13);
        }
        else if (index == 13){
            textComponent.text = string.Empty;
            HideDialogue();
            index++;
            StartCoroutine(NextLine(1f));
        }
        else if (index == 14){
            textComponent.text = string.Empty;
            HideDialogue();
            index++;
            cutscene[8].Play();
        }

        syncDialogueCount = 0;

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
