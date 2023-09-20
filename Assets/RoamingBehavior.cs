using UnityEngine;

public class RoamingBehavior : MonoBehaviour
{
    public float maxRoamingDistance = 5f; // Maximum distance the object can roam from its initial position.
    public float moveSpeed = 2f; // Speed at which the object moves.
    private Transform target;
    public float baseMoveSpeed = 5.0f;
    private bool targetIsActive = false;
    private Vector2 initialPosition;
    private Vector2 targetPosition;
    private Rigidbody2D rb;
    public Animator anim;
    private BoxCollider2D boxCollider;


    private void Start()
    {
        Debug.Log("Target is" + target);
        rb = GetComponent<Rigidbody2D>();
        initialPosition = rb.position;
        FindNewRandomTarget();
        boxCollider = GetComponent<BoxCollider2D>();
        SetColliderSize(8f, 15f, 15f);
    }

    private void Update()
    {
        if (!targetIsActive){
        if (Vector2.Distance(rb.position, targetPosition) < 0.1f)
        {
            FindNewRandomTarget();
        }
        }

        Vector2 moveDirection = (targetPosition - rb.position).normalized;
        rb.velocity = moveDirection * moveSpeed;

        if (anim.GetBool("isHiddenInTallGrass")){
            SetColliderSize(4f, 4f, 4f);
        }
        else{
            SetColliderSize(8f, 15f, 15f);
        }
        if (targetIsActive){
        Vector3 directionToTarget = (target.position - transform.position).normalized;
        float distanceToTarget = Vector3.Distance(transform.position, target.position);
        float moveSpeed = Mathf.Lerp(baseMoveSpeed, baseMoveSpeed * 2, Mathf.Clamp01(distanceToTarget / 10.0f));
        transform.position += directionToTarget * moveSpeed * Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            if (target == null){
            target = coll.gameObject.transform;
            targetIsActive = true;
            }
        }
    }



    private void FindNewRandomTarget()
    {
        targetPosition = initialPosition + Random.insideUnitCircle * maxRoamingDistance;
    }

    private void SetColliderSize(float offsetX, float sizeX, float sizeY)
    {
        if (boxCollider != null)
        {
            // Set the offset and size of the BoxCollider2D.
            boxCollider.offset = new Vector2(offsetX, 0f);
            boxCollider.size = new Vector2(sizeX, sizeY);
        }
    }
}
