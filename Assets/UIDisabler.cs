using UnityEngine;

public class UIDisabler : MonoBehaviour
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
        DisableAllUITaggedCanvases();
    }

    void DisableAllUITaggedCanvases()
    {
        // Get all GameObjects in the scene
        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();

        foreach (GameObject obj in allObjects)
        {
            // Check if the GameObject has the "UI" tag and a Canvas component
            if (obj.CompareTag("UI"))
            {
                Canvas canvas = obj.GetComponent<Canvas>();

                if (canvas != null)
                {
                    // Disable the Canvas
                    canvas.enabled = CutOut;
                }
            }
        }
    }

    public void EnableAllUITaggedCanvases()
    {
        CutOut = true;
    }

    
}
