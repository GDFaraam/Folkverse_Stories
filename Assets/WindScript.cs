using System.Collections;
using UnityEngine;

public class WindScript : MonoBehaviour
{
    public GameObject ballPrefab;
    public float spawnForce = 10.0f; // Adjust the force as needed
    public float destroyTime; // Time in seconds before the ball is destroyed
    private float spawnTime;
    private bool spawning = false;
    private float changeDirectionTime;
    private float direction;

    // Update is called once per frame
    void Update()
    {
        if (!spawning){
        StartCoroutine(SpawnBallAfterSeconds());
        }
    }

    void SpawnBall()
    {
    // Calculate the spawn position slightly in front of the player
    Vector3 spawnPosition = transform.position + transform.forward;

    // Instantiate the ball GameObject at the calculated position
    GameObject newBall = Instantiate(ballPrefab, spawnPosition, Quaternion.identity);

    // Get the Rigidbody2D component of the ball and apply a force in the forward direction with some randomness along the x-axis
    Rigidbody2D ballRigidbody = newBall.GetComponent<Rigidbody2D>();
    if (ballRigidbody != null)
    {
        // Calculate a forward direction with only positive x-axis component
        Vector2 spawnDirection = transform.forward + Vector3.right; // Positive x-axis component
        
        ballRigidbody.AddForce(spawnDirection.normalized * spawnForce, ForceMode2D.Impulse);
    }

        StartCoroutine(DestroyBall(newBall));
        StartCoroutine(ChangeDirection(newBall, destroyTime));
    }


    IEnumerator DestroyBall(GameObject ball)
    {
        destroyTime = Random.Range(6,10);
        yield return new WaitForSeconds(destroyTime);
        Destroy(ball);
    }

    IEnumerator SpawnBallAfterSeconds()
    {
        spawning = true;
        spawnTime = Random.Range(3,12);
        yield return new WaitForSeconds(spawnTime);
        SpawnBall();
        spawning = false;
    }

    IEnumerator ChangeDirection(GameObject ball, float destroyTime)
    {
        direction = Random.Range(-5f, 5f);
        float changeDirectionTime = destroyTime / 2;
        yield return new WaitForSeconds(changeDirectionTime);

        Rigidbody2D ballRigidbody = ball.GetComponent<Rigidbody2D>();
        if (ballRigidbody != null)
        {
        Vector2 newDirection = new Vector2(ballRigidbody.velocity.x, direction); // Change y-component to 2.0f
        ballRigidbody.velocity = newDirection;
        }
    }
}
