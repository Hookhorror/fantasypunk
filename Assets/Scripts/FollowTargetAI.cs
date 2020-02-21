using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTargetAI : MonoBehaviour
{
    public float speed;
    public Rigidbody2D target;
    public float spottingRange;
    public float firingRange;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletForce = 15;
    public Animator animator;

    private Vector2 lastPosition;
    private Vector2 movementDirection;

    void Awake()
    {
        lastPosition = transform.position;
    }

    void Update()
    {
        animator.SetFloat("Horizontal", movementDirection.x);
        animator.SetFloat("Vertical", movementDirection.y);
        animator.SetFloat("Speed", movementDirection.sqrMagnitude);

        float distanceToTarget = Vector2.Distance(transform.position
                                                , target.transform.position);

        ResetMovementDirection();

        if (distanceToTarget <= spottingRange)
        {
            SetMovementDirection();

            transform.position = Vector2.MoveTowards(transform.position
                              , target.position
                              , speed * Time.deltaTime);
        }
        // Shoot();

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
        movementDirection.x = target.position.x;
        movementDirection.y = target.position.y;
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
