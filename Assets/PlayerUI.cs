using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{


    [SerializeField] public PlayerMovement target;
    [SerializeField] public Joystick joystick;
    [SerializeField] public Button button;
    [SerializeField] public Button mic;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        this.transform.SetParent(GameObject.FindGameObjectWithTag("UI").gameObject.GetComponent<Transform>(), false);
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(this.gameObject);
            Debug.Log("UI fail");
            return;
        }


        if (target.joystick != null)
        {
            target.joystick = joystick;
            Debug.Log("joystick done");
        }
    }

    public void SetTarget(PlayerMovement _target)
    {
        if (_target == null)
        {
            Debug.LogError("<Color=Red><a>Missing</a></Color> PlayMakerManager target for PlayerUI.SetTarget.", this);
            return;
        }

        target = _target;
        
        
    }

    
}
