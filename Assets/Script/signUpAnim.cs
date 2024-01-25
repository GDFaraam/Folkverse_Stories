using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class signUpAnim : MonoBehaviour
{

    public Animator signupanim;
    public InputField inputField;
    public InputField sectionField;     
    // Start is called before the first frame update
    void Start()
    {
        signupanim = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loginPanel()
    {
        UISound.Instance.UIOpen();
        signupanim.SetBool("logtIsOpen", true);
    }

    public void signPanel()
    {
        UISound.Instance.UIOpen();
        signupanim.SetBool("logIsOpen", false);
    }

    public void logtOpen()
    {
        UISound.Instance.UIOpen();
        signupanim.SetBool("logtIsOpen", true);
        signupanim.SetBool("signIsOpen", false);
    }

    public void logtClose()
    {
        UISound.Instance.UIOpen();
        signupanim.SetBool("logtIsOpen", false);
    }

    public void logstOpen()
    {
        UISound.Instance.UIOpen();
        signupanim.SetBool("logstIsOpen", true);
    }

    public void logstClose()
    {
        UISound.Instance.UIOpen();
        signupanim.SetBool("logstIsOpen", false);
    }

    public void loginStudent()
    {
        UISound.Instance.UIOpen();
        string nickname = inputField.text;
        string section = sectionField.text;
        PlayerPrefs.SetString("PlayerNickname", nickname);
        PlayerPrefs.SetString("Section", section);
        SceneManager.LoadScene("LOADING TO MAIN STUD");
    }

    public void loginTeacher()
    {
        UISound.Instance.UIOpen();
        SceneManager.LoadScene("LOADING TO MAIN");
    }

    public void signInitial()
    {
        UISound.Instance.UIOpen();
        signupanim.SetBool("signIsOpen", true);
    }

    public void logInitial()
    {
        UISound.Instance.UIOpen();
        signupanim.SetBool("logIsOpenInitial", true);
        signupanim.SetBool("logIsOpen", true);
    }



}
