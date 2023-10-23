using UnityEngine;

public class RoamingBehavior : MonoBehaviour
{
    public float maxRoamingDistance = 5f;
    public float moveSpeed = 2f;
    private Vector2 initialPosition;
    private Vector2 targetPosition;
    private Rigidbody2D rb;
    private Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        initialPosition = rb.position;
        FindNewRandomTarget();
    }

    private void Update()
    {
        // Check if the object has reached its target position.
        if (Vector2.Distance(rb.position, targetPosition) < 0.1f)
        {
            FindNewRandomTarget();
        }

        // Move towards the target position.
        Vector2 moveDirection = (targetPosition - rb.position).normalized;
        rb.velocity = moveDirection * moveSpeed;

        // Update animator parameters based on the movement direction.
        UpdateAnimatorParameters(moveDirection);
    }

    private void FindNewRandomTarget()
    {
        // Generate a random target position within the maximum roaming distance.
        targetPosition = initialPosition + Random.insideUnitCircle * maxRoamingDistance;
    }

    private void UpdateAnimatorParameters(Vector2 moveDirection)
    {
        // Set boolean parameters in the animator based on the movement direction.
        animator.SetBool("isLeft", moveDirection.x < 0);
        animator.SetBool("isRight", moveDirection.x > 0);
    }

    void OnCollisionEnter2D(Collision2D coll){
        if (coll.gameObject.CompareTag("Tree")){
            FindNewRandomTarget();
        }
    }
}
