using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Transform[] spawnArea;
    public GameObject[] CheckPoints;
    public Button[] buttonList;
    public GameObject[] quizList;

    public bool DetachPressed = false;
    public bool isDashPressed = false;

    private int sprintIndex = 0;
    public bool isSprinting = false;

    public PlayerMovement playerMovement;

    public Canvas canvas;


    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    void Start(){
        canvas.gameObject.SetActive(false);
    }

    public void resetCheckPoints(){
        foreach (GameObject checkPointGo in CheckPoints){
            checkPointGo.gameObject.tag = "Checkpoint";
        }
    }

    public void Detach(){
        DetachPressed = true;
    }

    public void Dash(){
        isDashPressed = true;
        StartCoroutine(CoolDownB());
        buttonList[0].interactable = false;
    }

    IEnumerator CoolDownB(){
        yield return new WaitForSeconds(15f);
        buttonList[0].interactable = true;
    }

    public void Sprint(){
        if (sprintIndex == 0){
            sprintIndex = 1;
            isSprinting = true;
            playerMovement.playerSpeed = 6f;
            Debug.Log("Sprinting");
        }
        else if (sprintIndex == 1){
            sprintIndex = 0;
            isSprinting = false;
            playerMovement.playerSpeed = 3f;
            Debug.Log("Not Sprinting");
        }
    }

    public void SetCanvas(){
        canvas.gameObject.SetActive(true);
    }

}
