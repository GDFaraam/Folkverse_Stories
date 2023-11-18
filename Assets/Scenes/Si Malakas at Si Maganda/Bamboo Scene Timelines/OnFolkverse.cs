using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnFolkverse : MonoBehaviour
{
    public CutsceneBehavior cutsceneBehavior;

    void Start(){
        cutsceneBehavior.OnFolkverseScene = true;
    }
}
