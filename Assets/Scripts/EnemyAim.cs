using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAim : MonoBehaviour
{
    // TODO: Pubblegum solution, same target needs to be set now twice. Super stupid, fix!
    public Rigidbody2D target;

    // Update is called once per frame
    void Update()
    {



    }

    void FixedUpdate()
    {
        Vector2 lookDir = target.transform.position - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        // transform.RotateAround(transform.position, new Vector3(0, 0, 1), 1);
    }
}
