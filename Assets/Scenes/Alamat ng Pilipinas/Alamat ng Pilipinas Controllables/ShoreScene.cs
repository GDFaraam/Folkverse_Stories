using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
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
    private float textSpeed = 0.02f;
    private int index;

    private static ShoreScene SHOREinstance;

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
        storyScenes[0].SetActive(true);
        cutscene[0].Play();
        diaBox.SetActive(false);
        StartCoroutine(DialogueShow());
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

    public void NextButton(){
        if (index == 0){
            textComponent.text = string.Empty;
            index++;
            StartCoroutine(NextLine(2f));
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
            StartCoroutine(RescueScene());
        }

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
        buttons[0].interactable = true;
        sceneObjects[1].SetActive(true);
    }

    IEnumerator RescueScene(){
        yield return new WaitForSeconds(2f);
        ANPDialogue.instance.index = 13;
        SceneManager.LoadScene(12);
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
