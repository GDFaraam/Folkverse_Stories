using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class SceneManigger : MonoBehaviour
{
    public PlayableDirector[] cutscene;
    public GameObject[] sceneObjects;
    public Button[] buttons;

    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    public int index;

    void Start(){
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
        buttons[0].interactable = false;
        sceneObjects[0].SetActive(true);
        cutscene[1].Play();
        sceneObjects[1].SetActive(false);
        StartCoroutine(TypeLine());
    }

    public void HideDialogue(){
        sceneObjects[0].SetActive(false);
    }

    public void NextButton(){
        if (textComponent.text == lines[index]){
            if (textComponent.text == lines[0]){
                HideDialogue();
            }
            else if (textComponent.text == lines[1]){
                HideDialogue();
                sceneObjects[2].SetActive(true);
                sceneObjects[3].SetActive(true);
                cutscene[2].Play();
                StartCoroutine(NextDialogue());
            }
            else if (textComponent.text == lines[5]){
                HideDialogue();
                cutscene[3].Play();
                StartCoroutine(NextScene());
            }
            else{
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
            }
        }

        if (index == 0){
            cutscene[0].Play();
            StartCoroutine(NextDialogue());
        }
    }

    IEnumerator TypeLine(){
        foreach (char c in lines[index].ToCharArray()){
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        sceneObjects[1].SetActive(true);
        buttons[0].interactable = true;
    }

    IEnumerator NextDialogue(){
        yield return new WaitForSeconds(6f);
        index++;
        ShowDialogue();
    }
    
    IEnumerator NextScene(){
        yield return new WaitForSeconds(9f);
        SceneManager.LoadScene(2);
    }
}
