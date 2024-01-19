using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        map = GameObject.FindGameObjectWithTag("mapbutton");
        map.gameObject.SetActive(mapbuttonon);
    }
}
