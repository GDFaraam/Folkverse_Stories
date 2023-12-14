using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;   

public class SpawnPlayers : MonoBehaviour
{
    
    public GameObject studentPrefabs;
    public GameObject teacherPrefabs;
    
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

            string role = DeterminePlayerRole();
            
            Vector2 randomposition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

            GameObject playerPrefab = GetPlayerPrefab(role);

            PhotonNetwork.Instantiate(playerPrefab.name, randomposition, Quaternion.identity);

            Debug.Log("spawned players with role: " + role);
        }
        else
        {
            GameObject.FindWithTag("Player").transform.position = this.gameObject.transform.position;
        }

        
        
    }

    string DeterminePlayerRole()
    {
        RoleChecker roleChecker = RoleChecker.Instance;

        // Check if a role has been assigned
        if (!string.IsNullOrEmpty(roleChecker.role))
        {
            return roleChecker.role;
        }

        return roleChecker.role;
    }

    GameObject GetPlayerPrefab(string role)
    {
        if (role == "Teacher")
        {
            return teacherPrefabs;
        }
        else
        {
            return studentPrefabs;
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
