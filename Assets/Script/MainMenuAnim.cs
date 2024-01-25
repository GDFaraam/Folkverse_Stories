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
        UISound.Instance.UIOpen();
        UIanim.SetBool("playIsOpen", true);
    }

    public void playClose()
    {
        UISound.Instance.UIOpen();
        UIanim.SetBool("playIsOpen", false);
    }

    public void settingsOpen()
    {
        UISound.Instance.UIOpen();
        UIanim.SetBool("setIsOpen", true);
    }

    public void settingClose()
    {
        UISound.Instance.UIOpen();
        UIanim.SetBool("setIsOpen", false);
    }

    public void htpOpen()
    {
        UISound.Instance.UIOpen();
        UIanim.SetBool("htpIsOpen", true);
    }

    public void htpClose()
    {
        UISound.Instance.UIOpen();
        UIanim.SetBool("htpIsOpen", false);
    }

    public void credOpen()
    {
        UISound.Instance.UIOpen();
        UIanim.SetBool("credIsOpen", true);
    }

    public void credClose()
    {
        UISound.Instance.UIOpen();
        UIanim.SetBool("credIsOpen", false);
    }

    public void Quit()
    {
        UISound.Instance.UIOpen();
        Application.Quit();
    }

    public void loginTButton()
    {
        UISound.Instance.UIOpen();
        SceneManager.LoadScene("LOADING TO MAIN");
    }

    public void loginSTButton()
    {
        UISound.Instance.UIOpen();
        SceneManager.LoadScene("LOADING TO MAIN STUD");
    }

    public void joinOpen()
    {
        UISound.Instance.UIOpen();
        UIanim.SetBool("joinIsOpen", true);
        Debug.Log("openIsJoin");
    }

    public void joinClose()
    {
        UISound.Instance.UIOpen();
        UIanim.SetBool("joinIsOpen", false);
    }

    public void createOpen()
    {
        UISound.Instance.UIOpen();
        UIanim.SetBool("createIsOpen", true);
    }

    public void createClose()
    {
        UISound.Instance.UIOpen();
        UIanim.SetBool("createIsOpen", false);
    }

    public void assOpen()
    {
        UISound.Instance.UIOpen();
        UIanim.SetBool("assIsOpen", true);
    }

    public void assClose()
    {
        UISound.Instance.UIOpen();
        UIanim.SetBool("assIsOpen", false);
    }

    public void assMalakasPre()
    {
        UISound.Instance.UIOpen();
        SceneManager.LoadScene("MalakasExam"); 
    }

    public void assPilipinasPre()
    {
        UISound.Instance.UIOpen();
        SceneManager.LoadScene("PilipinasExam");
    }

    public void attendanceOpen()
    {
        UISound.Instance.UIOpen();
        UIanim.SetBool("openAttendanceSheet", true);
    }

    public void attendanceClose()
    {
        UISound.Instance.UIOpen();
        UIanim.SetBool("openAttendanceSheet", false);
    }

    

}
