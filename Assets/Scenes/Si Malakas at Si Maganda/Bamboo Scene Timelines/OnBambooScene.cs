using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBambooScene : MonoBehaviour
{
    public CutsceneBehavior cutsceneBehavior;

    void Start(){
        cutsceneBehavior.OnFolkverseScene = false;
    }
}
