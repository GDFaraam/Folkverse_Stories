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
    public RoleChecker role;
    public bool Teacher = false;
    [SerializeField] public Joystick joystick;
    public static GameObject LocalPlayerInstance;
    public PhotonView view;
    [SerializeField]public Animator characterAnimator; 
    [SerializeField]public Animator characterAnimatorShadow;
    [SerializeField] public GameObject PlayerUIPrefab;
    public float speed;

    void Start()
    {
        
        rb = this.gameObject.GetComponent<Rigidbody2D>();

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

        if(photonView.IsMine)
        {
            if(PlayerUIPrefab != null)
            {
            GameObject _uiGo = Instantiate(PlayerUIPrefab);
            _uiGo.SendMessage ("SetTarget", this, SendMessageOptions.RequireReceiver);
            }
        else
            {
            Debug.LogWarning("<Color=Red><a>Missing</a></Color> PlayerUiPrefab reference on player Prefab.", this);
        }
        }
        

        

    }



    void Update()
    {


        joystick = this.gameObject.transform.GetChild(5).gameObject.transform.GetChild(0).gameObject.GetComponent<Joystick>();

        speed = movement.sqrMagnitude;

        if(photonView.IsMine)
        {

            movement.x = joystick.Horizontal;
            movement.y = joystick.Vertical;
        
        }
        
            characterAnimator.SetFloat("Horizontal", movement.x);
            characterAnimator.SetFloat("Vertical", movement.y);
            characterAnimator.SetFloat("speed", speed);


 


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

    void CalledOnLevelWasLoaded()
    {
        GameObject _uiGo = Instantiate(this.PlayerUIPrefab);
        _uiGo.SendMessage("SetTarget", this, SendMessageOptions.RequireReceiver);
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
