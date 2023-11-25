using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuAnim : MonoBehaviour
{

    public Animator UIanim;
    public bool playUI;
    // Start is called before the first frame update
    void Start()
    {
        UIanim = this.gameObject.GetComponent<Animator>();
        playUI = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayOpen()
    {
        UIanim.SetBool("playIsOpen", true);
    }

    public void playClose()
    {
        UIanim.SetBool("playIsOpen", false);
    }

    public void settingsOpen()
    {
        UIanim.SetBool("setIsOpen", true);
    }

    public void settingClose()
    {
        UIanim.SetBool("setIsOpen", false);
    }

    public void htpOpen()
    {
        UIanim.SetBool("htpIsOpen", true);
    }

    public void htpClose()
    {
        UIanim.SetBool("htpIsOpen", false);
    }

    public void credOpen()
    {
        UIanim.SetBool("credIsOpen", true);
    }

    public void credClose()
    {
        UIanim.SetBool("credIsOpen", false);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void loginTButton()
    {
        SceneManager.LoadScene("LOADING TO MAIN");
    }

    public void loginSTButton()
    {
        SceneManager.LoadScene("LOADING TO MAIN STUD");
    }

    public void joinOpen()
    {
        UIanim.SetBool("joinIsOpen", true);
        Debug.Log("openIsJoin");
    }

    public void joinClose()
    {
        UIanim.SetBool("joinIsOpen", false);
    }

    public void createOpen()
    {
        UIanim.SetBool("createIsOpen", true);
    }

    public void createClose()
    {
        UIanim.SetBool("createIsOpen", false);
    }

}
