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
        sceneObjects[0].SetActive(true);
        cutscene[1].Play();
        StartCoroutine(TypeLine());
    }

    public void HideDialogue(){
        sceneObjects[0].SetActive(false);
    }


    public void NextButton()
    {
        string role = (string)photonView.Owner.CustomProperties["Role"];

        if (role == "Teacher")
        {
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
        }
    }


    IEnumerator TypeLine(){
        buttons[0].interactable = false;
        sceneObjects[6].SetActive(false);
        foreach (char c in lines[index].ToCharArray()){
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        buttons[0].interactable = true;
        sceneObjects[6].SetActive(true);
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
