using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class QuitRoom : MonoBehaviourPunCallbacks
{
    public string teacherSceneName; // Assign the name of the scene for the teacher
    public string studentSceneName; // Assign the name of the scene for the student

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public override void OnLeftRoom()
    {
        LoadSceneBasedOnRole();
    }

    public void LeaveRoomAndLoadScene()
    {
        PhotonNetwork.LeaveRoom();
    }

    void LoadSceneBasedOnRole()
    {
        if (PhotonNetwork.LocalPlayer != null && PhotonNetwork.LocalPlayer.CustomProperties.TryGetValue("Role", out object roleObj))
        {
            string currentPlayerRole = (string)roleObj;
            string nextSceneName = (currentPlayerRole == "Teacher") ? teacherSceneName : studentSceneName;

            if (!string.IsNullOrEmpty(nextSceneName))
            {
                SceneManager.LoadScene(nextSceneName);
            }
            else
            {
                Debug.LogWarning("Invalid scene name.");
            }
        }
        else
        {
            Debug.LogWarning("Role not found in Custom Properties.");
        }
    }
}
