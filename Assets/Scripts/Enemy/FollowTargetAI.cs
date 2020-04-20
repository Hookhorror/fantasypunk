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
    public float bulletForce = 15;
    public Animator animator;

    private Vector2 lastPosition;
    private Vector2 movementDirection;
    private bool shooting = false;
    private GameObject target;

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
        animator.SetFloat("Horizontal", movementDirection.x);
        animator.SetFloat("Vertical", movementDirection.y);
        animator.SetFloat("Speed", movementDirection.sqrMagnitude);

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

        if (distanceToTarget <= attackRange && !shooting)
        {
            shooting = true;
            InvokeRepeating("Shoot", 1f, 1f);
        }
        else if (distanceToTarget > attackRange && shooting)
        {
            shooting = false;
            CancelInvoke("Shoot");
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
