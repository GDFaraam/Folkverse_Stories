using UnityEngine;

public class SetCamera : MonoBehaviour
{
    void Start()
    {
        // Assuming your Canvas is attached to the same GameObject as this script
        Canvas canvas = GetComponent<Canvas>();

        // Check if the Canvas component exists
        if (canvas != null)
        {
            // Find the camera with the tag "mapmap"
            Camera mapCamera = GameObject.FindGameObjectWithTag("mapmap").GetComponent<Camera>();

            // Check if the camera is found
            if (mapCamera != null)
            {
                // Set the event camera of the canvas to the found camera
                canvas.worldCamera = mapCamera;
            }
            else
            {
                Debug.LogError("Camera with tag 'mapmap' not found.", this);
            }

            // Optionally, you can also set the render mode if needed
            // canvas.renderMode = RenderMode.WorldSpace;
        }
        else
        {
            Debug.LogError("Canvas component not found on the GameObject.", this);
        }
    }
}
