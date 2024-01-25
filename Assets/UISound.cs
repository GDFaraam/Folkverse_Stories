using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISound : MonoBehaviour
{
    public static UISound Instance;
    
    public AudioClip[] audioClips;

    private AudioSource audioSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void UIOpen(){
        audioSource.clip = audioClips[0];
        audioSource.Play();
    }
    public void UIClose(){
        audioSource.clip = audioClips[1];
        audioSource.Play();
    }
}
