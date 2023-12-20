using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
public class cameraDisable : MonoBehaviour
{
    public bool CutOut = false;
    public CameraFix cameraFix;
    public UIDisabler uiDisabler;
    private PhotonView view;

    void Start()
    {
        view = this.GetComponent<PhotonView>();
    }

    void Awake()
    {
        
    }

    void Update()
    {
        DisableCameraFollowTeacher();
        DisableCameraFollowStudent();
    }

    void DisableCameraFollowTeacher()
    {
        // Get all GameObjects in the scene
        GameObject[] teacherObjects = GameObject.FindGameObjectsWithTag("Teacher");

        foreach (GameObject obj in teacherObjects)
        {
            CameraWork cameraWork = obj.GetComponent<CameraWork>();

            if (cameraWork != null)
            {
                cameraWork.enabled = CutOut;
            }
        }
    }

    void DisableCameraFollowStudent()
    {
        GameObject[] allObjects = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject obj in allObjects)
        {
            CameraWork cameraWork = obj.GetComponent<CameraWork>();

            if (cameraWork != null)
            {
                cameraWork.enabled = CutOut;
            }
        }
    }


    public void EnableAllUITaggedCanvases()
    {
        CutOut = true;
    }

    public void ExitToLobby(){
        if (view.IsMine)
        {
            view.RPC("ExitStory", RpcTarget.All);
        }
    }

    [PunRPC]
    public void ExitStory(){
        CutOut = true;
        uiDisabler.CutOut = true;
        cameraFix.PositionToLobby();
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.LoadLevel(1);
    }
    
}
