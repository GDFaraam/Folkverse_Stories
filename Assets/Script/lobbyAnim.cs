using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lobbyAnim : MonoBehaviour
{

    public Animator lobbyanim;
    // Start is called before the first frame update
    void Start()
    {
        lobbyanim = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void bookOpen()
    {
        lobbyanim.SetBool("storyIsOpen", true);
    }

    public void bookClose()
    {
        lobbyanim.SetBool("storyIsOpen", true);
    }

    public void page2()
    {
        lobbyanim.SetFloat("pageNo", 2);    
    }

    public void page3()
    {
        lobbyanim.SetFloat("pageNo", 3);
    }

    public void startGame()
    {
        SceneManager.LoadScene(6);
    }
}
