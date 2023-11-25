using UnityEngine;
using Photon.Pun;

public class CameraWork : MonoBehaviour
{

    Transform cameraTransform;
    bool isFollowing;
    public bool followOnStart = false;

    void Start()
    {
        if (followOnStart)
        {
            OnStartFollowing();
        }
    }

    void LateUpdate()
    {
        if(cameraTransform == null && isFollowing)
        {
            OnStartFollowing();
        }

        if(isFollowing)
        {
            Follow();
        }
    }

    public void OnStartFollowing()
    {
        cameraTransform = Camera.main.transform;
        isFollowing = true;
    }

    void Follow()
    {
        cameraTransform.position = this.gameObject.transform.position;
    }



}