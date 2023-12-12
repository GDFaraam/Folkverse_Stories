using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDisabler : MonoBehaviour
{

    public static UIDisabler Instance;
    public bool CutOut = true;
    public GameObject Teachers;
    public GameObject Students;
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        if(Instance = null)
        {
            Instance = this;
        }
    }


}
