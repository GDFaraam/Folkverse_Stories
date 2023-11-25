using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SRSpawn : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame 
    
    public GameObject playerPrefabs;

    void Start()
    {
        GameObject.FindWithTag("Player").transform.position = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {

    }



}
