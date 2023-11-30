using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindPhysics : MonoBehaviour
{
    public AudioClip audioClip; 
    private AudioSource audioSource;

    public Material[] Grasses;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioClip != null)
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        }

        StartCoroutine(StartSpeed());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator StartSpeed(){
        yield return new WaitForSeconds(4f);
    }
}
