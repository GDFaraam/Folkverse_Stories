using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMicButton : MonoBehaviour
{


    [SerializeField] public PlayerMovement target;
    [SerializeField] public Button button;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        this.transform.SetParent(GameObject.Find("Mic").GetComponent<Transform>(), false);
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
