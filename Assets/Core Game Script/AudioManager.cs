using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] audioClip; 
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void StartBGMusic(){
        audioSource.clip = audioClip[0];
        audioSource.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
