using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAim : MonoBehaviour
{
    // TODO: Pubblegum solution, same target needs to be set now twice. Super stupid, fix!
    public Rigidbody2D target;

    private float angle;
    private Vector2 lookDir;

    // Update is called once per frame
    void Update()
    {
        // Updates the looking direction and counts the angle of aiming
        Vector2 lookDir = target.transform.position - transform.position;
        angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
    }

    void FixedUpdate()
    {
        // Turns the aim
        transform.rotation = Quaternion.Euler(0, 0, angle);

        // transform.RotateAround(transform.position, new Vector3(0, 0, 1), 1);
    }
}
