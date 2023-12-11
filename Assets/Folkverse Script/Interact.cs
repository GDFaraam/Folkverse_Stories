using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class Interact : MonoBehaviour
{
    public bool isInteract = false;
    public GameObject fadeOutObject;
    public PlayableDirector fadeOut;

    public InteractStone interactStone; 

    void Start()
    {
    
    }

    void OnTriggerEnter2D(Collider2D coll){

        if (coll.gameObject.CompareTag("Teacher")){
        isInteract = true;
        }
    }

    void OnTriggerExit2D(Collider2D coll){

        if (coll.gameObject.CompareTag("Teacher")){
        isInteract = true;
        }
    }

    public void InteractPhoenix(){
        if (isInteract){
            fadeOutObject.SetActive(true);
            fadeOut.Play();
            StartCoroutine(phoenixScene());
        }
    }

    IEnumerator phoenixScene(){
        yield return new WaitForSeconds (1.5f);
        SceneManager.LoadScene(4);
    }
}
