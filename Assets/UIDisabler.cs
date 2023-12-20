using UnityEngine;

public class UIDisabler : MonoBehaviour
{
    public bool CutOut = false;

    void Update()
    {
        DisableSpecificChildrenInUITaggedCanvases();
    }

    void DisableSpecificChildrenInUITaggedCanvases()
    {
        // Find all Canvas objects with the "UI" tag
        Canvas[] uiCanvases = GameObject.FindObjectsOfType<Canvas>();
        foreach (Canvas canvas in uiCanvases)
        {
            if (canvas.CompareTag("UI"))
            {
                DisableSpecificChildren(canvas.transform);
            }
        }
    }

    // Disable specific children of a parent Transform
    void DisableSpecificChildren(Transform parent)
    {
        // Example: Disable children at specific indices
        int[] childIndicesToDisable = { 0, 1 }; // Adjust these indices as needed

        foreach (int index in childIndicesToDisable)
        {
            if (index >= 0 && index < parent.GetChild(0).gameObject.transform.childCount)
            {
                Transform child = parent.GetChild(0).gameObject.transform.GetChild(index);
                child.gameObject.SetActive(CutOut);
            }
            else
            {
                Debug.LogWarning("Index out of range: " + index);
            }
        }
    }

    public void EnableAllUITaggedCanvases()
    {
        CutOut = true;
    }
}
