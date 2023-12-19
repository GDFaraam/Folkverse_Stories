using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFix : MonoBehaviour
{
    void Start()
    {
        GameObject teacher = GameObject.FindWithTag("Teacher");
        if (teacher != null)
        {
            teacher.transform.position = this.gameObject.transform.position;
            InteractStone interactStoneTeacher = teacher.GetComponent<InteractStone>();
            interactStoneTeacher.addedOne = false;
        }

        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject playerGo in players)
        {
            playerGo.transform.position = this.gameObject.transform.position;

            InteractStone interactStone = playerGo.GetComponent<InteractStone>();

            if (interactStone != null)
            {
                interactStone.addedOne = false;
            }
        }
    }
}
