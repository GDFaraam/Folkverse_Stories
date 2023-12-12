using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class formChanger : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Teacher;

    void Start()
    {
            
        Teacher = GameObject.FindGameObjectWithTag("Teacher");

        PlayerMovement playerMovement = Teacher.GetComponent<PlayerMovement>();
        playerMovement.phoenixForm();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
