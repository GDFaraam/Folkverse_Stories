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

    public GameObject[] spawnPoint;

    public RequiredPlayers requiredPlayers;

    void OnEnable(){
        requiredPlayers.UnlockRoom();
    }


    [PunRPC]
    // Start is called before the first frame update
    private void Start()
    {
        AudioController.ACinstance.PlayAudioClip(1); 
        if (PlayerMovement.LocalPlayerInstance == null)
        {
            string role = DeterminePlayerRole();

            int randomSpawnpoint = Random.Range(0, 5);

            Transform spawnTransform = spawnPoint[randomSpawnpoint].transform;
            Vector3 randomPosition = spawnTransform.position;

            GameObject playerPrefab = GetPlayerPrefab(role);

            PhotonNetwork.Instantiate(playerPrefab.name, randomPosition, Quaternion.identity);

            Debug.Log("Spawned player with role: " + role);
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
