using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;   

public class SpawnPlayers : MonoBehaviour
{
    
    public GameObject playerPrefabs;
    
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;


    [PunRPC]
    // Start is called before the first frame update
    private void Start()
    {   



        if(PlayerMovement.LocalPlayerInstance == null)
        {
            Vector2 randomposition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            PhotonNetwork.Instantiate(playerPrefabs.name, randomposition, Quaternion.identity);
            Debug.Log("spawned players");
        }
        else
        {
            GameObject.FindWithTag("Player").transform.position = this.gameObject.transform.position;
        }

        
        
    }

    // Update is called once per frame
    void Update()   
    {
        
    }

    void Awake()
    {

    }


    void SpawnOther()
    {

    }


    


}
