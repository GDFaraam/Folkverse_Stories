using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class QuitRoom : MonoBehaviourPunCallbacks
{
    public string teacherSceneName; // Assign the name of the scene for the teacher
    public string studentSceneName; // Assign the name of the scene for the student


    public static QuitRoom instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this) {
            Destroy(instance.gameObject);
            DontDestroyOnLoad(gameObject);
        }
    }

    void Update()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        
        if (currentScene == "MAIN MENU TEACHER" || currentScene == "MAIN MENU STUDENT")
        {
            Destroy(this.gameObject);
        }
    }

    public void LeaveRoomAndLoadScene(string quittingPlayerRole)
    {
        PhotonNetwork.LeaveRoom();
        LoadSceneBasedOnRole(quittingPlayerRole);
    }

    void LoadSceneBasedOnRole(string role)
    {
        if (teacherSceneName != null)
        {
            string currentPlayerRole = role;
            string nextSceneName = (currentPlayerRole == "Teacher") ? teacherSceneName : studentSceneName;

            if (!string.IsNullOrEmpty(nextSceneName))
            {
                Debug.Log("Loading scene: " + nextSceneName);
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
