using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class signUpAnim : MonoBehaviour
{

    public Animator signupanim;
    public InputField inputField;    
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
        signupanim.SetBool("logIsOpen", true);
    }

    public void signPanel()
    {
        signupanim.SetBool("logIsOpen", false);
    }

    public void logtOpen()
    {
        signupanim.SetBool("logtIsOpen", true);
    }

    public void logtClose()
    {
        signupanim.SetBool("logtIsOpen", false);
    }

    public void logstOpen()
    {
        signupanim.SetBool("logstIsOpen", true);
    }

    public void logstClose()
    {
        signupanim.SetBool("logstIsOpen", false);
    }

    public void loginStudent()
    {
        string nickname = inputField.text;
        PlayerPrefs.SetString("PlayerNickname", nickname);
        SceneManager.LoadScene("LOADING TO MAIN STUD");
    }

    public void loginTeacher()
    {
        SceneManager.LoadScene("LOADING TO MAIN");
    }

}
