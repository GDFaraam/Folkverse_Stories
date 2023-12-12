using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButton : MonoBehaviour
{


    public bool htpVisibility = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(htpVisibility == true)
        {

        }
        else
        {

        }
    }

    public void loginStudent()
    {
        SceneManager.LoadScene(4);
    }

    public void loginTeacher()
    {
        SceneManager.LoadScene(3);
    }

    public void logAsTeach()
    {
        SceneManager.LoadScene(1);
    }

    public void logAsStudent()
    {
        SceneManager.LoadScene(2);
    }

    public void joinStud()
    {
        SceneManager.LoadScene(14);
    }

    public void joinTeach()
    {
        SceneManager.LoadScene(5);
    }

    public void createRoom()
    {
        SceneManager.LoadScene(12);
    }

    public void htpTeach()
    {
        if(htpVisibility == true)
        {
            htpVisibility = false;
        }
        else
        {
            htpVisibility = true;
        }
    }

    public void htpStud()
    {
        SceneManager.LoadScene(9);
    }   

    public void setStud()
    {
        SceneManager.LoadScene(11);
    }

    public void setTeach()
    {
        SceneManager.LoadScene(10);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void logAs()
    {
        SceneManager.LoadScene(0);
    }

    public void enterLobby()
    {
        SceneManager.LoadScene(12);
    }

    

}
