using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class formChanger : MonoBehaviour
{
    public bool changeForm;

    private GameObject Teacher;
    private PlayerMovement playerMovement;

    void Start()
    {  
        Teacher = GameObject.FindGameObjectWithTag("Teacher");
        playerMovement = Teacher.GetComponent<PlayerMovement>();
        ChangeForm();
    }

    void Update(){
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject playerGo in players)
        {
            PlayerMovement playerMovement = playerGo.GetComponent<PlayerMovement>();
            if (changeForm)
            {
                playerMovement.moveSpeed = 5f;
                playerMovement.speed = 5f;
            }
            else{
                playerMovement.moveSpeed = 2f;
                playerMovement.speed = 2f;
            }
        }
    }

    public void ChangeForm(){
        if (changeForm){
            playerMovement.phoenixForm();
        }
        else{
            playerMovement.teacherForm();
        }
    }

    
}
