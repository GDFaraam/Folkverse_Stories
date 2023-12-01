using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    public GameObject cloudPrefab;  // The prefab of the cloud
    public float speed = 5.0f;      // The constant speed of the cloud
    public Vector3 spawnPoint;      // The spawn point for the cloud
    public float minInterval = 3.0f;  // Minimum time interval for cloud spawning
    public float maxInterval = 7.0f;  // Maximum time interval for cloud spawning

    private float nextSpawnTime;     // Time to spawn the next cloud

    void Start()
    {
        // Schedule the first cloud spawn immediately
        SpawnCloud();
    }

    void Update()
    {
        // Check if it's time to spawn a cloud
        if (Time.time >= nextSpawnTime)
        {
            // Spawn a cloud
            SpawnCloud();
        }
    }

    void SpawnCloud()
    {
        // Spawn a cloud
        GameObject newCloud = Instantiate(cloudPrefab, spawnPoint, Quaternion.identity);

        // Set the cloud's constant speed
        Cloud cloudScript = newCloud.GetComponent<Cloud>();
        cloudScript.SetSpeed(speed);

        // Schedule the next cloud spawn with a new random interval
        nextSpawnTime = Time.time + Random.Range(minInterval, maxInterval);
    }
}
