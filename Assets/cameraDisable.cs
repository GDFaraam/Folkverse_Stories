using UnityEngine;

public class cameraDisable : MonoBehaviour
{

    public bool CutOut = false;

    void Start()
    {
        
    }

    void Awake()
    {
        
    }

    void Update()
    {
        DisableCameraFollowTeacher();
        DisableCameraFollowStudent();
    }

    void DisableCameraFollowTeacher()
    {
        // Get all GameObjects in the scene
        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();

        foreach (GameObject obj in allObjects)
        {
            // Check if the GameObject has the "UI" tag and a Canvas component
            if (obj.CompareTag("Teacher"))
            {
                CameraWork cameraWork = obj.GetComponent<CameraWork>();

                if (cameraWork != null)
                {
                    // Disable the Canvas
                    cameraWork.enabled = CutOut;
                }
            }
        }
    }

    void DisableCameraFollowStudent()
    {
        // Get all GameObjects in the scene
        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();

        foreach (GameObject obj in allObjects)
        {
            // Check if the GameObject has the "UI" tag and a Canvas component
            if (obj.CompareTag("Player"))
            {
                CameraWork cameraWork = obj.GetComponent<CameraWork>();

                if (cameraWork != null)
                {
                    // Disable the Canvas
                    cameraWork.enabled = CutOut;
                }
            }
        }
    }


    public void EnableAllUITaggedCanvases()
    {
        CutOut = true;
    }

    
}
