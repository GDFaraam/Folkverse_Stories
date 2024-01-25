using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class miniMapCreate : MonoBehaviour
{

    public Camera camera;
    public bool cameraBool;
    public int newPriority = 1;
    public GameObject ExButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        camera = GameObject.FindGameObjectWithTag("mapmap").gameObject.GetComponent<Camera>();
        string currentScene = SceneManager.GetActiveScene().name;
        
        if (currentScene == "MAIN MENU TEACHER" || currentScene == "MAIN MENU STUDENT")
        {
            Destroy(this.gameObject);
        }
    }

    public void CameraOff()
    {
        UISound.Instance.UIOpen();
        if(cameraBool != true)
        {
            cameraBool = true;
            camera.depth = newPriority;
            ExButton.SetActive(true);
        }
        else
        {
            cameraBool = false;
            camera.depth = -2;
            ExButton.SetActive(false);
        }
    }


}
