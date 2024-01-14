using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class SyncWorldSpaceCanvas : MonoBehaviourPun, IPunObservable
{
    public InputField teacherInputField;
    public RawImage studentImage;
    public Text studentText;

    private bool isTeacher;

    void Start()
    {
        // Retrieve the role assigned to the local player
        if (PhotonNetwork.LocalPlayer.CustomProperties.TryGetValue("Role", out object role))
        {
            isTeacher = (string)role == "Teacher";
            teacherInputField.gameObject.SetActive(isTeacher);
            studentText.gameObject.SetActive(!isTeacher);
            studentImage.gameObject.SetActive(!isTeacher);
        }
        else
        {
            Debug.LogWarning("Role not found for the local player.");
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            if (isTeacher)
            {
                string textToSend = teacherInputField.text;
                stream.SendNext(textToSend);
            }
        }
        else
        {
            if (!isTeacher)
            {
                string receivedText = (string)stream.ReceiveNext();
                studentText.text = receivedText;

                // Assuming the image is stored as a Texture2D or an image URL in a variable named 'imageData'
                // Load the image data or URL into the RawImage component for students
                // Example:
                // Texture2D receivedImage = LoadImageFromData(imageData);
                // studentImage.texture = receivedImage;
            }
        }
    }
}
