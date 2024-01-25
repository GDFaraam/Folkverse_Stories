using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetQuitComponent : MonoBehaviour
{
    private string yourRole;
    public PlayerRole playerRole;

    public void Quit(){
        UISound.Instance.UIOpen();
        yourRole = playerRole.role;
        QuitRoom quit = GameObject.FindWithTag("Quit")?.GetComponent<QuitRoom>();
        quit.LeaveRoomAndLoadScene(yourRole);
    }
}
