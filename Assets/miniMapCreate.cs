using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniMapCreate : MonoBehaviour
{

    public GameObject camera;
    public bool cameraBool;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        camera = GameObject.FindGameObjectWithTag("MiniMap");
    }

    public void CameraOff()
    {
        if(cameraBool != true)
        {
            cameraBool = true;
            camera.gameObject.SetActive(cameraBool);
        }
        else
        {
            cameraBool = false;
            camera.gameObject.SetActive(cameraBool);
        }
        
    }


}
