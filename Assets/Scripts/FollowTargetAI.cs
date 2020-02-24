using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTargetAI : MonoBehaviour
{
    public float speed;
    public Rigidbody2D target;
    public float spottingRange;
    public float attackRange;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletForce = 15;
    public Animator animator;

    private Vector2 lastPosition;
    private Vector2 movementDirection;
    private bool shooting = false;

    void Awake()
    {
        lastPosition = transform.position;
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

            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
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
        // TODO: Do some research which works better for enemy turning

        float hypotenuse = Mathf.Sqrt((target.position.x * target.position.x) + (target.position.y * target.position.y));
        movementDirection.x = target.position.x / hypotenuse;
        movementDirection.y = target.position.y / hypotenuse;

        // movementDirection.x = target.position.x;
        // movementDirection.y = target.position.y;

        Debug.Log("enemy x: " + movementDirection.x);
        Debug.Log("enemy y: " + movementDirection.y);
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        // Adds rigidbody to the bullet
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        // Makes the bullet fly in simple
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
