using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MalakasIntroStart : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] players;

    void Start()
    {
        GameObject.FindWithTag("Boy").transform.position = this.gameObject.transform.position;
    }

    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
