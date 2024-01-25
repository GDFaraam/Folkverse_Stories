using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mapDisabler : MonoBehaviour
{

    public GameObject map;
    public bool mapbuttonon = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        
        if (currentScene == "Lobby World Map")
        {
            map.gameObject.SetActive(true);
        }
        else{
            map.gameObject.SetActive(false);
        }
    }
}
