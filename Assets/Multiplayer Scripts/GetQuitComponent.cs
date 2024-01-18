using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetQuitComponent : MonoBehaviour
{
    private string yourRole;
    public PlayerRole playerRole;

    public void Quit(){
        yourRole = playerRole.role;
        QuitRoom.instance.LeaveRoomAndLoadScene(yourRole);
    }
}
