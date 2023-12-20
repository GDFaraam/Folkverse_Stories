using UnityEngine;

public class UIDisabler : MonoBehaviour
{
    public bool CutOut = false;
    public int firstChildToDisableIndex = 0; // Index of the first child to be disabled
    public int secondChildToDisableIndex = 1; // Index of the second child to be disabled

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
                Transform parent = canvas.transform.parent;

                if (parent.CompareTag("Teacher"))
                {
                    DisableTeacherSpecificChildren(parent, 2); // Canvas placed at index 2 for Teacher
                }
                else if (parent.CompareTag("Player"))
                {
                    DisableStudentSpecificChildren(parent, 1); // Canvas placed at index 1 for Student
                }
            }
        }
    }

    // Disable specific children for a teacher role
    void DisableTeacherSpecificChildren(Transform parent, int canvasIndex)
    {
        int emptyGameObjectIndex = canvasIndex + 1; // Index after Canvas for Teacher

        if (emptyGameObjectIndex < parent.childCount)
        {
            Transform emptyGameObject = parent.GetChild(emptyGameObjectIndex);

            // Disable two specific children based on the indices within the emptyGameObject
            DisableSpecificChildren(emptyGameObject, firstChildToDisableIndex, secondChildToDisableIndex);
        }
        else
        {
            Debug.LogWarning("Empty GameObject index out of range");
        }
    }

    // Disable specific children for a student role
    void DisableStudentSpecificChildren(Transform parent, int canvasIndex)
    {
        int emptyGameObjectIndex = canvasIndex + 1; // Index after Canvas for Student

        if (emptyGameObjectIndex < parent.childCount)
        {
            Transform emptyGameObject = parent.GetChild(emptyGameObjectIndex);

            // Disable two specific children based on the indices within the emptyGameObject
            DisableSpecificChildren(emptyGameObject, firstChildToDisableIndex, secondChildToDisableIndex);
        }
        else
        {
            Debug.LogWarning("Empty GameObject index out of range");
        }
    }

    // Disable two specific children based on the provided indices within the emptyGameObject
    void DisableSpecificChildren(Transform emptyGameObject, int firstChildIndex, int secondChildIndex)
    {
        if (emptyGameObject.childCount > 0)
        {
            Transform childOfEmpty = emptyGameObject.GetChild(0);

            if (firstChildIndex >= 0 && firstChildIndex < childOfEmpty.childCount &&
                secondChildIndex >= 0 && secondChildIndex < childOfEmpty.childCount)
            {
                Transform firstChildToDisable = childOfEmpty.GetChild(firstChildIndex);
                Transform secondChildToDisable = childOfEmpty.GetChild(secondChildIndex);

                firstChildToDisable.gameObject.SetActive(CutOut);
                secondChildToDisable.gameObject.SetActive(CutOut);
            }
            else
            {
                Debug.LogWarning("Child index to disable out of range");
            }
        }
        else
        {
            Debug.LogWarning("No children found for the empty GameObject");
        }
    }

    public void EnableAllUITaggedCanvases()
    {
        CutOut = true;
    }
}
