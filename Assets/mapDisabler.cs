using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapDisabler : MonoBehaviour
{
    
    public GameObject map;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        map = GameObject.FindGameObjectWithTag("MiniMap");
        map.gameObject.SetActive(false);
    }
}
