using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RoleChecker : MonoBehaviourPun
{
    // Start is called before the first frame update

    public bool TeacherRole = false;
    public PhotonView pv;

    void Start()
    {

        pv = this.gameObject.GetComponent<PhotonView>();

        if(pv.Owner.IsMasterClient == true)
        {
            TeacherRole = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
