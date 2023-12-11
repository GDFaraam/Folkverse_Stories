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
    [SerializeField] public GameObject PlayerUIPrefab;
    public float speed;
    private bool inTeacherForm = true;
    private bool inPhoenixform = false;

    
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

            phoenixAnimator.SetFloat("Horizontal", movement.x);
            phoenixAnimator.SetFloat("Vertical", movement.y);
            phoenixAnimator.SetFloat("Speed", speed);
        
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

    public void ToggleForm()
    {

    }

    public void phoenixForm()
    {
        inPhoenixform = true;
        phoenixObj.SetActive(inPhoenixform);
        inTeacherForm = false;
        teacherObj.SetActive(inTeacherForm);
    }









}
