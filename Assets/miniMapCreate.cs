using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


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
        camera = GameObject.FindGameObjectWithTag("MiniMap").gameObject.GetComponent<Camera>();
        string currentScene = SceneManager.GetActiveScene().name;
        
        if (currentScene == "MAIN MENU TEACHER" || currentScene == "MAIN MENU STUDENT")
        {
            Destroy(this.gameObject);
        }
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
