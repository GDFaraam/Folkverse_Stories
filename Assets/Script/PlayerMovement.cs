using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMovement : MonoBehaviourPun
{
    public float moveSpeed = 5f;
    private Vector3 targetPosition;

    public Rigidbody2D rb;
    Vector2 movement;
    Vector2 lastMoveDirection;

    public RoleChecker role;
    public bool Teacher = false;

    public JoystickMovement joystickMovement;
    
    public static GameObject LocalPlayerInstance;

    public PhotonView view;

    void Start()
    {
        
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        joystickMovement = this.gameObject.transform.GetChild(4).gameObject.transform.GetChild(0).gameObject.GetComponent<JoystickMovement>();

        CameraWork _cameraWork = this.gameObject.GetComponent<CameraWork>();

         if (_cameraWork != null)
        {
            if (photonView.IsMine)
            {
                _cameraWork.OnStartFollowing();
            }
        }
        else
        {
             Debug.LogError("<Color=Red><a>Missing</a></Color> CameraWork Component on playerPrefab.", this);
        }




        

    }

    void Update()
    {
        if (photonView.IsMine)
        {


            movement = joystickMovement.joystickVec;
        }

        if (!photonView.IsMine)
        {
            return;
        }


        Teacher = role;
    }

    private void Awake() 
    {
        if(photonView.IsMine)
        {
            LocalPlayerInstance = this.gameObject;
        }    

        DontDestroyOnLoad(this.gameObject);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "TPStory")
        {
            if (Teacher)
            {
                view.RPC("RPC_TPStory", RpcTarget.All);
                Debug.Log("Teleporting to Story Room");
            }
        }

        if (other.gameObject.name == "TPLobby")
        {
            if (Teacher)
            {
                view.RPC("RPC_TPLobby", RpcTarget.All);
                Debug.Log("Teleporting to Lobby");
            }
        }
    }

    [PunRPC]
    void RPC_TPStory()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.LoadLevel("STORY ROOM");
    }

    [PunRPC]
    void RPC_TPLobby()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.LoadLevel("NEW LOBBY");
    }
}
