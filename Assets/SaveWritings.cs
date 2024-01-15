using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;

public class SaveWritings : MonoBehaviour
{
    public TMP_InputField textOnBoard;
    private PhotonView view;
    private string previousText;

    void Start()
    {
        view = GetComponent<PhotonView>();
        if (view.IsMine)
        {
            view.RPC("GetSavedWritings", RpcTarget.All);
            StartCoroutine(UpdateTextRoutine());
        }
    }

    private IEnumerator UpdateTextRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f); // Wait for 5 seconds

            // Save and sync text every 5 seconds
            PlayerPrefs.SetString("BoardText", textOnBoard.text);

            if (textOnBoard.text != previousText)
            {
                ThrowTextOnOtherPlayers();
                previousText = textOnBoard.text;
            }
        }
    }

    public void ThrowTextOnOtherPlayers()
    {
        view.RPC("SyncBoardText", RpcTarget.All, textOnBoard.text);
    }

      private void UpdateInputFieldOwnership()
        {
            if (view.IsMine)
            {
                textOnBoard.interactable = true;
            }
            else
            {
                textOnBoard.interactable = false;
            }
        }

    void Update(){
        UpdateInputFieldOwnership();
    }

    [PunRPC]
    public void GetSavedWritings()
    {
        string writingsOnBoard = PlayerPrefs.GetString("BoardText");
        textOnBoard.text = writingsOnBoard;
        previousText = writingsOnBoard;
        Debug.Log("GetSavedWritings called. New text: " + writingsOnBoard);
    }

    [PunRPC]
    public void SyncBoardText(string newText)
    {
        textOnBoard.text = newText;
        previousText = newText;
        Debug.Log("SyncBoardText called. New text: " + newText);
    }

}