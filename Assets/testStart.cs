using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class testStart : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject examObjects;
    public Button mainmenu;
    public Button startButton;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startExam()
    {
        examObjects.SetActive(true);
        mainmenu.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MAIN MENU STUDENT");
    }
}
