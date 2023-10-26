using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    private float speed;

    // Set the cloud's speed
    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    void Update()
    {
        // Move the cloud in the positive direction
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        // Destroy the cloud after the specified duration
        Destroy(gameObject, 50.0f);
    }
}
