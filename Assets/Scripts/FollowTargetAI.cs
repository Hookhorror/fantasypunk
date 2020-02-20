using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTargetAI : MonoBehaviour
{
    public float speed;
    public Transform[] checkpoints;
    public Rigidbody2D target;
    public float spottingRange;
    public float firingRange;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletForce = 15;
    public Animator animator;

    private Vector2 lastPosition;
    private Vector2 movement;

    void Awake()
    {
        lastPosition = transform.position;
    }

    void Update()
    {
        // transform.position = Vector2.MoveTowards(transform.position
        //                    , checkpoints[randomCheckpoint].position
        //                    , speed * Time.deltaTime);
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        float distanceToTarget = Vector2.Distance(transform.position
                                                , target.transform.position);

        if (distanceToTarget <= spottingRange)
        {
            movement = Vector2.MoveTowards(transform.position
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

    private void TurnToMovementDirection()
    {
        if (lastPosition.x < transform.position.x)
        {
        }
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
