using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractStone : MonoBehaviour
{
    public bool canTransition = false;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("StonePedestal"))
        {
            canTransition = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("StonePedestal"))
        {
            canTransition = false;
        }
    }

    void Update()
    {
         
    }

    public void NextScene(){
        if(canTransition){
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
        canTransition = false;
        }
    }
}
