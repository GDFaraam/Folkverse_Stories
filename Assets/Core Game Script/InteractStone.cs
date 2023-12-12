using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class InteractStone : MonoBehaviour
{
    public bool canTransition = false;
    public bool canANP = false;
    public PhotonView view;

    void Start()
    {
        view = this.gameObject.GetComponent<PhotonView>();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("StonePedestal"))
        {
            canTransition = true;
        }

        if (other.gameObject.CompareTag("Longer Pole"))
        {
            canANP = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("StonePedestal"))
        {
            canTransition = false;
        }

        if (other.gameObject.CompareTag("Longer Pole"))
        {
            canANP = false;
        }
    }

    void Update()
    {
         
    }

    
    public void NextScene()
    {
        if(canTransition)
        {
            view.RPC("NextScenePun", RpcTarget.All);
        }
        if (canANP){
            ANPScene();
        }
    }

    public void ANPScene()
    {
        if(canANP)
        {
            view.RPC("ANPcut", RpcTarget.All);
        }
    }

    [PunRPC]
     void ANPcut()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.LoadLevel(12);
        canANP = false;
    }

    [PunRPC]
     void NextScenePun()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        PhotonNetwork.LoadLevel(nextSceneIndex);
        canTransition = false;
    }
}
