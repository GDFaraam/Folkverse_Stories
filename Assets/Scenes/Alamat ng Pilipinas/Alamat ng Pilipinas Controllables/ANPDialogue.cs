using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Playables;

public class ANPDialogue : MonoBehaviour
{
    public PlayableDirector[] cutscene;
    public PlayableDirector[] transitions;
    public GameObject[] storyScenes;
    public Button[] buttons;
    public GameObject[] characters;

    public GameObject diaBox;
    
    public TextMeshProUGUI textComponent;
    public string[] lines;
    private float textSpeed = 0.02f;
    private int index;

    void Start(){
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

    IEnumerator DialogueShow(){
        yield return new WaitForSeconds(3f);
        ShowDialogue();
    }

    public void ShowDialogue(){
        textComponent.text = string.Empty;
        buttons[0].interactable = false;
        diaBox.SetActive(true);
        StartCoroutine(TypeLine());
    }

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

    }

    IEnumerator NextLine(float duration){
        yield return new WaitForSeconds(duration);
        ShowDialogue();
    }

    IEnumerator TypeLine(){
        foreach (char c in lines[index].ToCharArray()){
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        buttons[0].interactable = true;
    }

    public void HideDialogue(){
        diaBox.SetActive(false);
    }

    public void CaveScene(){
        storyScenes[0].SetActive(false);
        storyScenes[2].SetActive(true);
        cutscene[1].Play();
        buttons[1].gameObject.SetActive(false);
        characters[0].SetActive(true);
        StartCoroutine(DialogueShow());
    }
}
