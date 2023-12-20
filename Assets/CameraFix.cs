using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFix : MonoBehaviour
{
    public GameObject lobbyPosition;

    private GameObject teacher; 
    private GameObject[] players;

    void Start()
    {
        GameObject findTeacher = GameObject.FindWithTag("Teacher");
        GameObject[] findPlayers = GameObject.FindGameObjectsWithTag("Player");
        players = findPlayers;
        teacher = findTeacher;
        FixCamera();
    }

    void Update(){
        GameObject findTeacher = GameObject.FindWithTag("Teacher");
        GameObject[] findPlayers = GameObject.FindGameObjectsWithTag("Player");
    }

    public void FixCamera()
    {
        if (teacher != null)
        {
            teacher.transform.position = transform.position;
            InteractStone interactStoneTeacher = teacher.GetComponent<InteractStone>();
            if (interactStoneTeacher != null)
            {
                interactStoneTeacher.addedOne = false;
            }
        }

        foreach (GameObject playerGo in players)
        {
            playerGo.transform.position = transform.position;

            InteractStone interactStone = playerGo.GetComponent<InteractStone>();

            if (interactStone != null)
            {
                interactStone.addedOne = false;
            }
        }
    }

    public void PositionToLobby()
    {
        if (teacher != null)
        {
            teacher.transform.position = lobbyPosition.transform.position;
            InteractStone interactStoneTeacher = teacher.GetComponent<InteractStone>();
            if (interactStoneTeacher != null)
            {
                interactStoneTeacher.addedOne = false;
            }
        }

        foreach (GameObject playerGo in players)
        {
            playerGo.transform.position = lobbyPosition.transform.position;

            InteractStone interactStone = playerGo.GetComponent<InteractStone>();

            if (interactStone != null)
            {
                interactStone.addedOne = false;
            }
        }
    }
}
