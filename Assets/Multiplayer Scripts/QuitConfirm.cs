using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitConfirm : MonoBehaviour
{
    public GameObject quitObject;

    public GameObject settings;

    public GameObject volumeSettings;

    public void OpenSettings(){
        UISound.Instance.UIOpen();
        settings.SetActive(true); 
    }

    public void CloseSettings(){
        UISound.Instance.UIOpen();
        settings.SetActive(false); 
    }

    public void OpenVolumeSettings(){
        UISound.Instance.UIOpen();
        volumeSettings.SetActive(true); 
    }

    public void CloseVolumeSettings(){
        UISound.Instance.UIOpen();
        volumeSettings.SetActive(false); 
    }

    public void OpenPanel(){
        UISound.Instance.UIOpen();
        quitObject.SetActive(true);
    }

    public void ClosePanel(){
        UISound.Instance.UIOpen();
        quitObject.SetActive(false);
    }
}
