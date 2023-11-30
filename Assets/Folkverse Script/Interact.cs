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

    void OnTriggerEnter2D(Collider2D coll){
        if (coll.gameObject.CompareTag("Boy")){
        isInteract = true;
        }
    }

    void OnTriggerExit2D(Collider2D coll){
        if (coll.gameObject.CompareTag("Boy")){
        isInteract = false;
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
        SceneManager.LoadScene(3);
    }
}
