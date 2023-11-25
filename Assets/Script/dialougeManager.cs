using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialougeManager : MonoBehaviour
{


    public Text nameText;
    public Text dialougeText;

    public Animator animator;

    private Queue<string> sentences;


    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartDialouge  (Dialouge dialouge)
    {
        Debug.Log ("starting convo with " + dialouge.name);

        animator.SetBool("isOpen", true);

        nameText.text = dialouge.name;


        sentences.Clear();

        foreach (string sentence in dialouge.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence ()
    {
        if(sentences.Count == 0)
        {
            EndDialouge();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        Debug.Log(sentence);
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialougeText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialougeText.text += letter;
            yield return new WaitForSeconds(.1f);
        }
    }

    void EndDialouge()
    {
        Debug.Log("end of convo");
        animator.SetBool("isOpen", false);        
    }
}
