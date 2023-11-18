using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Playables;

public class CutsceneBehavior : MonoBehaviour
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

    void Start()
    {
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
        buttons[0].interactable = false;
        sceneObjects[0].SetActive(true);
        cutscene[0].Play();
        StartCoroutine(TypeLine());
    }

    public void ShowDialogueBamboo(){
        textComponent.text = string.Empty;
        buttons[0].interactable = false;
        sceneObjects[0].SetActive(true);
        cutscene[0].Play();
        StartCoroutine(TypeLineBamboo());
    }

    public void NextButton(){
        Debug.Log("Button Pressed");
        if (lines.Length == 1){
        if (OnFolkverseScene){
            if (textComponent.text == lines[index]){
            if (textComponent.text == lines[0]){
                HideDialogue();
                OnBambooScene = true;
                }
            }
        }
        if (!OnBambooScene){
            if (textComponent.text == lines[index]){
            if (textComponent.text == lines[0]){
                HideDialogue();
                StartCoroutine(BambooLines(2f));
                OnBambooScene = true;
                }
            }
        }
        }
        else if (lines.Length > 1){
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
            if (index == 3){
                HideDialogue();
                textComponent.text = string.Empty;
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
            StartCoroutine(BambooLines(2f));
            HideDialogue();
        }

        else if (bambooLinesIndex == 3){
            textComponent.text = string.Empty;
            bambooLinesIndex++;
            StartCoroutine(BambooLines(2f));
            HideDialogue();
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
            StartCoroutine(TypeLineBamboo());
        }

        else if (bambooLinesIndex == 8){
            textComponent.text = string.Empty;
            bambooLinesIndex++;
            HideDialogue();
        }

    }

    public void HideDialogue(){
        sceneObjects[0].SetActive(false);
    }

    IEnumerator TypeLine(){
        foreach (char c in lines[index].ToCharArray()){
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        buttons[0].interactable = true;
    }

    IEnumerator TypeLineBamboo(){
        foreach (char c in bambooLines[bambooLinesIndex].ToCharArray()){
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        buttons[0].interactable = true;
    }
}
