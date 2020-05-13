using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTargetAI : MonoBehaviour
{
    public float speed;
    // public Rigidbody2D target;
    public float spottingRange;
    public float attackRange;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletForce = 25;
    public Animator animator;

    private Vector2 lastPosition;
    private Vector2 movementDirection;
    private GameObject target;

    private double fireTimer;

    void Awake()
    {
        lastPosition = transform.position;
    }

    void Start()
    {
        target = PlayerManager.instance.player;

        // InvokeRepeating("ConsoleMessage", 1f, 1f);
    }

    void Update()
    {
        fireTimer -= Time.deltaTime;

        animator.SetFloat("Horizontal", movementDirection.x);
        animator.SetFloat("Vertical", movementDirection.y);
        animator.SetFloat("Speed", movementDirection.sqrMagnitude);
        // animator.SetBool("Dead", gameObject.GetComponentInParent<Enemy>().Dead());
        // gameObject.GetComponent<PolygonCollider2D>().autoTiling = true;
        

        float distanceToTarget = Vector2.Distance(transform.position, target.transform.position);

        ResetMovementDirection();

        if (distanceToTarget <= spottingRange)
        {
            SetMovementDirection();

            // Old version of movement without lerp
            /* transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime); */

            // Movement with lerp
            transform.position = Vector3.Lerp(transform.position
                                            , Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime)
                                            , 0.5f);
        }

        if (distanceToTarget <= attackRange && fireTimer<=0)
        {
            Shoot();
            fireTimer = 1;
        }
    }

    void FixedUpdate()
    {
        // GameObject aim = GetComponentInChildren<GameObject>();
        // aim.transform.rotation = Quaternion.RotateTowards(transform.rotation, target.transform.rotation, 0.1f);
        // Debug.Log(aim);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, spottingRange);
    }

    private void ResetMovementDirection()
    {
        movementDirection.x = 0;
        movementDirection.y = 0;
    }
    private void SetMovementDirection()
    {
        movementDirection.x = target.transform.position.x - transform.position.x;
        movementDirection.y = target.transform.position.y - transform.position.y;
        // Not quite sure if this is needed at all
        movementDirection = movementDirection.normalized;
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        // Adds rigidbody to the bullet
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        // Makes the bullet fly in simple
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

    // For debugging purposes
    private void ConsoleMessage()
    {
        Debug.Log("x: " + movementDirection.x + " y: " + movementDirection.y);
    }
}
