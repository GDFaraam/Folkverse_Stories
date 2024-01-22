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
    [SerializeField] public Joystick joystick;
    public static GameObject LocalPlayerInstance;
    [SerializeField]public Animator characterAnimator; 
    [SerializeField]public Animator characterAnimatorShadow;
    [SerializeField] public SpriteRenderer phoenix;
    [SerializeField] public Animator phoenixAnimator;
    [SerializeField] public Animator phoenixAnimatorShadow;
    [SerializeField] public GameObject PlayerUIPrefab;
    [SerializeField] public BoxCollider2D boxCollider2D;

    public float speed;
    private bool inTeacherForm = true;
    private bool inPhoenixform = false;
    public GameObject mapCam;

    public bool cameraBool;
    


    [SerializeField] public GameObject teacherObj;
    [SerializeField] public GameObject phoenixObj;  

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
            if (PlayerUIPrefab != null)
            {
                GameObject _uiGo =  Instantiate(PlayerUIPrefab);
                _uiGo.SendMessage ("SetTarget", this, SendMessageOptions.RequireReceiver);
                Debug.Log("UI Instantiated");
            }
            else
            {
                Debug.LogWarning("<Color=Red><a>Missing</a></Color> PlayerUIPrefab reference on player Prefab.", this);
            }
        }
        

        

    }



    void Update()
    {
        speed = movement.sqrMagnitude;

        if (photonView.IsMine)
        {
            movement.x = joystick.Horizontal;
            movement.y = joystick.Vertical;
        }
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

        if(photonView.IsMine)

        {
            float horizontalMovement = Mathf.Abs(movement.x);
            float verticalMovement = Mathf.Abs(movement.y);

            characterAnimator.SetFloat("Horizontal", movement.x);
            characterAnimator.SetFloat("Vertical", movement.y);
            characterAnimator.SetFloat("speed", horizontalMovement + verticalMovement);

            characterAnimatorShadow.SetFloat("Horizontal", movement.x);
            characterAnimatorShadow.SetFloat("Vertical", movement.y);
            characterAnimatorShadow.SetFloat("speed", horizontalMovement + verticalMovement);

            phoenixAnimator.SetFloat("Horizontal", movement.x);
            phoenixAnimator.SetFloat("Vertical", movement.y);
            phoenixAnimator.SetFloat("Speed", speed);
            phoenixAnimatorShadow.SetFloat("Horizontal", movement.x);
            phoenixAnimatorShadow.SetFloat("Vertical", movement.y);
            phoenixAnimatorShadow.SetFloat("Speed", speed);
        }
    }

    void CalledOnLevelWasLoaded()
    {
        GameObject _uiGo = Instantiate(this.PlayerUIPrefab);
        _uiGo.SendMessage("SetTarget", this, SendMessageOptions.RequireReceiver);
    }

    public void CameraOff()
    {
        if(cameraBool != true)
        {
            cameraBool = true;
            GetComponent<Camera>().gameObject.SetActive(cameraBool);
        }
        else
        {
            cameraBool = false;
            GetComponent<Camera>().gameObject.SetActive(cameraBool);
        }
        
    }

    public void phoenixForm()
    {   
        inPhoenixform = true;
        phoenixObj.SetActive(inPhoenixform);
        inTeacherForm = false;
        teacherObj.SetActive(inTeacherForm);
        boxCollider2D.enabled = false;
        moveSpeed = 6f;
    }

    public void teacherForm()
    {
        inPhoenixform = false;
        phoenixObj.SetActive(inPhoenixform);
        inTeacherForm = true;
        teacherObj.SetActive(inTeacherForm);
        boxCollider2D.enabled = true;
        moveSpeed = 2f;
    }
}
