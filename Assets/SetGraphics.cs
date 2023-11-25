using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGraphics : MonoBehaviour
{
    void Start()
    {
        SwitchQualityLevel();
    }

    private void SwitchQualityLevel()
    {
        QualitySettings.SetQualityLevel(3);
        Debug.Log("Set Quality to 1");
    }
}