using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Voice.Unity;
using UnityEngine.EventSystems;

public class PushToTalkButton : MonoBehaviourPunCallbacks, IPointerDownHandler, IPointerUpHandler
{
    public Recorder recorder;

    private bool isButtonDown = false;

    void Start()
    {
        if (recorder == null)
        {
            recorder = GetComponent<Recorder>();
            if (recorder == null)
            {
                Debug.LogError("Recorder component not found!");
                return;
            }
        }

        recorder.TransmitEnabled = false; // Initially, transmission is disabled
    }

    void Update()
    {
        recorder = GameObject.FindGameObjectWithTag("Recorder").GetComponent<Recorder>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isButtonDown = true;
        recorder.TransmitEnabled = true; // Enable transmission when the button is pressed
        Debug.Log("Mic is on");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isButtonDown = false;
        recorder.TransmitEnabled = false; // Disable transmission when the button is released
        Debug.Log("Mic is off");
    }
}
