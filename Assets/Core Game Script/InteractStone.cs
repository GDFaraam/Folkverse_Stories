using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class InteractStone : MonoBehaviour
{
    public RequiredPlayers reqPlayers;
    private bool interactPedestal = false;
    private bool MalakasAtM = false;
    private bool AlamatNgP = false;
    private bool StoryRoom = false;
    public bool addedOne = false;
    private PhotonView view;

    void Start(){
        view = this.gameObject.GetComponent<PhotonView>();
    }

    void Update()
    {
        GameObject CountManager = GameObject.FindWithTag("Playercount");

        if (CountManager != null)
        {
            reqPlayers = CountManager.GetComponent<RequiredPlayers>();

            if (reqPlayers == null)
            {
                Debug.LogError("RequiredPlayers script not found on the object with the 'Playercount' tag.");
            }
        }
        else
        {
            Debug.LogError("GameObject with tag 'Playercount' not found in the scene.");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("StonePedestal"))
        {
            interactPedestal = true;
            MalakasAtM = true;
        }

        if (other.gameObject.CompareTag("Longer Pole"))
        {
            interactPedestal = true;
            AlamatNgP = true;
        }

        if (other.gameObject.CompareTag("StoryRoom"))
        {
            interactPedestal = true;
            StoryRoom = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("StonePedestal"))
        {
            interactPedestal = false;
            MalakasAtM = false;
        }

        if (other.gameObject.CompareTag("Longer Pole"))
        {
            interactPedestal = false;
            AlamatNgP = false;
        }
        if (other.gameObject.CompareTag("StoryRoom"))
        {
            interactPedestal = false;
            StoryRoom = false;
        }
    }

    public void ToggleCountAll(){
        view.RPC("ToggleCount", RpcTarget.All);
    }

    [PunRPC]
    public void ToggleCount()
    {
        if (MalakasAtM){
            view.RPC("ToggleMAMCanvas", RpcTarget.All);
        }
        else if (AlamatNgP){
            view.RPC("ToggleANPCanvas", RpcTarget.All);
        }
        else if (StoryRoom){
            view.RPC("SetStoryRoom", RpcTarget.All);
        }
        if (interactPedestal && !addedOne)
        {
            view.RPC("AddCurrentCount", RpcTarget.All);
            addedOne = true;
        }
    }

    [PunRPC]
    public void ToggleMAMCanvas(){
        if (reqPlayers.indicators[0] != null){
        reqPlayers.indicators[0].SetActive(true);
        }
        if (reqPlayers.indicators[1] != null){
        reqPlayers.indicators[1].SetActive(false);
        }
    }

    [PunRPC]
    public void ToggleANPCanvas(){
        if (reqPlayers.indicators[0] != null){
        reqPlayers.indicators[0].SetActive(false);
        }
        if (reqPlayers.indicators[1] != null){
        reqPlayers.indicators[1].SetActive(true);
        }
    }

    [PunRPC]
    public void AddCurrentCount(){
        reqPlayers.requiredCount++;
    }

    [PunRPC]
    public void SubCurrentCount(){
        reqPlayers.requiredCount--;
    }

    [PunRPC]
    public void SetStoryRoom(){
        reqPlayers.RunStoryRoom();
    }

}
