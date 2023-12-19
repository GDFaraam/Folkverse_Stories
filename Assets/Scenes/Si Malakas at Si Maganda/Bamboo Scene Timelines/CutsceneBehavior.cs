using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Playables;
using Photon.Pun;

public class CutsceneBehavior : MonoBehaviourPunCallbacks
{
    public PlayableDirector[] cutscene;
    public Button[] buttons;
    public GameObject[] sceneObjects;
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public string[] bambooLines;
    public float textSpeed;
    public int index;
    public int bambooLinesIndex;
    public bool OnBambooScene = false;
    public bool OnFolkverseScene = false;

    public UIDisabler uiDisabler;

    public bool onOutro = false;

    private PhotonView view;
    private PlayerRole playerRole;

    void Start()
    {
        view = this.gameObject.GetComponent<PhotonView>();
        GameObject teacher = GameObject.FindWithTag("Teacher");
        playerRole = teacher.gameObject.GetComponent<PlayerRole>();
        uiDisabler.CutOut = false;
        sceneObjects[0].SetActive(false);
        StartCoroutine(DialogueShow());
    }

    IEnumerator BambooLines(float duration){
        yield return new WaitForSeconds(duration);
        ShowDialogueBamboo();
    }

    IEnumerator DialogueShow(){
        yield return new WaitForSeconds(2f);
        ShowDialogue();
    }

    public void ShowDialogue(){
        textComponent.text = string.Empty;
        sceneObjects[0].SetActive(true);
        cutscene[0].Play();
        StartCoroutine(TypeLine());
    }

    public void ShowDialogueBamboo(){
        textComponent.text = string.Empty;
        sceneObjects[0].SetActive(true);
        cutscene[0].Play();
        StartCoroutine(TypeLineBamboo());
    }

    public void NextButtonAll()
    {
        if (view.IsMine && playerRole.role == "Teacher")
        {
            view.RPC("NextButton", RpcTarget.All);
        }
    }

    [PunRPC]
    public void NextButton()
    {
            if (lines.Length == 1)
                {
                    if (OnFolkverseScene)
                    {
                        if (textComponent.text == lines[index])
                        {
                            if (textComponent.text == lines[0])
                            {
                                HideDialogue();
                                uiDisabler.EnableAllUITaggedCanvases();
                                if (!OnBambooScene)
                                {
                                    StartCoroutine(BambooLines(2f));
                                    OnBambooScene = true;
                                }
                            }
                        }
                    }
                }

                else if (lines.Length > 1)
                {
                    index++;
                    textComponent.text = string.Empty;
                    StartCoroutine(TypeLine());
                    if (index == 3)
                    {
                        HideDialogue();
                        textComponent.text = string.Empty;
                        uiDisabler.EnableAllUITaggedCanvases();
                    }
                }

                if (textComponent.text == bambooLines[0]){
                    bambooLinesIndex++;
                    textComponent.text = string.Empty;
                    HideDialogue();
                    StartCoroutine(BambooLines(2f));
                }
                if (bambooLinesIndex == 1){
                    textComponent.text = string.Empty;
                    HideDialogue();
                    bambooLinesIndex++;
                }

                else if (bambooLinesIndex == 2){
                    textComponent.text = string.Empty;
                    bambooLinesIndex++;
                    StartCoroutine(BambooLines(1.5f));
                    HideDialogue();
                }

                else if (bambooLinesIndex == 3){
                    textComponent.text = string.Empty;
                    bambooLinesIndex++;
                    if(!onOutro){
                    StartCoroutine(BambooLines(2f));
                    HideDialogue();
                    }
                    else{
                    HideDialogue();
                    }
                }

                else if (bambooLinesIndex == 4){
                    textComponent.text = string.Empty;
                    bambooLinesIndex++;
                    StartCoroutine(BambooLines(2f));
                    HideDialogue();
                }

                else if (bambooLinesIndex == 5){
                    textComponent.text = string.Empty;
                    bambooLinesIndex++;
                    cutscene[1].Play();
                    StartCoroutine(BambooLines(2f));
                    HideDialogue();
                }

                else if (bambooLinesIndex == 6){
                    textComponent.text = string.Empty;
                    bambooLinesIndex++;
                    StartCoroutine(BambooLines(4f));
                    HideDialogue();
                }

                if (textComponent.text == bambooLines[7]){
                    textComponent.text = string.Empty;
                    bambooLinesIndex++;
                    StartCoroutine(BambooLines(3f));
                    HideDialogue();
                }

                else if (bambooLinesIndex == 8){
                    textComponent.text = string.Empty;
                    bambooLinesIndex++;
                    cutscene[2].Play();
                    StartCoroutine(BambooLines(7f));
                    HideDialogue();
                }

                else if (bambooLinesIndex == 9){
                    textComponent.text = string.Empty;
                    bambooLinesIndex++;
                    StartCoroutine(BambooLines(3f));
                    HideDialogue();
                }

                else if (bambooLinesIndex == 10){
                    textComponent.text = string.Empty;
                    bambooLinesIndex++;
                    StartCoroutine(BambooLines(2f));
                    HideDialogue();
                }

                else if (bambooLinesIndex == 11){
                    textComponent.text = string.Empty;
                    bambooLinesIndex++;
                    StartCoroutine(BambooLines(2f));
                    HideDialogue();
                }
                else if (bambooLinesIndex == 12){
                    textComponent.text = string.Empty;
                    bambooLinesIndex++;
                    StartCoroutine(TypeLineBamboo());
                }
                else if (bambooLinesIndex == 13){
                    textComponent.text = string.Empty;
                    bambooLinesIndex++;
                    StartCoroutine(TypeLineBamboo());
                }
                else if (bambooLinesIndex == 14){
                    textComponent.text = string.Empty;
                    bambooLinesIndex++;
                    StartCoroutine(BambooLines(2f));
                    HideDialogue();
                }

                else if (bambooLinesIndex == 15)
                {
                    textComponent.text = string.Empty;
                    bambooLinesIndex++;
                    cutscene[3].Play();
                    HideDialogue();
                }
            }


    public void HideDialogue(){
        sceneObjects[0].SetActive(false);
    }

    IEnumerator TypeLine(){
        sceneObjects[1].SetActive(false);
        buttons[0].interactable = false;
        foreach (char c in lines[index].ToCharArray()){
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        buttons[0].interactable = true;
        sceneObjects[1].SetActive(true);
    }

    IEnumerator TypeLineBamboo(){
        sceneObjects[1].SetActive(false);
        buttons[0].interactable = false;
        foreach (char c in bambooLines[bambooLinesIndex].ToCharArray()){
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        buttons[0].interactable = true;
        sceneObjects[1].SetActive(true);
    }

    public void CallOnOutro(){
        onOutro = true;
    }
}
