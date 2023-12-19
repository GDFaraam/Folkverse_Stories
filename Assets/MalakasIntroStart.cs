using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MalakasIntroStart : MonoBehaviour
{
    // Start is called before the first frame update


    void Start()
    {
        GameObject.FindWithTag("Teacher").transform.position = this.gameObject.transform.position;
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject playerGo in players)
        {
            playerGo.transform.position = this.gameObject.transform.position;
        }
    }

}
