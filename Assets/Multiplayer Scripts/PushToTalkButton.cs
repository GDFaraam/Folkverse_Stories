using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Voice.Unity;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PushToTalkButton : MonoBehaviourPunCallbacks, IPointerDownHandler, IPointerUpHandler
{
    public Recorder recorder;
    private Image buttonImage;
    public Sprite pressedSprite; // Assign the pressed sprite in the inspector
    private Sprite originalSprite;

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

        recorder.TransmitEnabled = false; 

        
        buttonImage = GetComponent<Image>();
        if (buttonImage != null)
        {
            originalSprite = buttonImage.sprite;
        }
    }

    void Update()
    {
        recorder = GameObject.FindGameObjectWithTag("Recorder").GetComponent<Recorder>();
        string currentScene = SceneManager.GetActiveScene().name;
        
        if (currentScene == "MAIN MENU TEACHER" || currentScene == "MAIN MENU STUDENT")
        {
            Destroy(this.gameObject);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isButtonDown = true;
        recorder.TransmitEnabled = true; 
        if (buttonImage != null && pressedSprite != null)
        {
            buttonImage.sprite = pressedSprite;
        }

        Debug.Log("Mic is on");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isButtonDown = false;
        recorder.TransmitEnabled = false; 
        if (buttonImage != null)
        {
            buttonImage.sprite = originalSprite;
        }

        Debug.Log("Mic is off");
    }
}
