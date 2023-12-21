using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioController.ACinstance.PlayAudioClip(3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
