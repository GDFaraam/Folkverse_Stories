using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniMapCreate : MonoBehaviour
{

    public Camera camera;
    public bool cameraBool;
    public int newPriority = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        camera = GameObject.FindGameObjectWithTag("mapmap").gameObject.GetComponent<Camera>();
    }

    public void CameraOff()
    {
        if(cameraBool != true)
        {
            cameraBool = true;
            camera.depth = newPriority;
        }
        else
        {
            cameraBool = false;
            camera.depth = -2;
        }
        
    }


}
