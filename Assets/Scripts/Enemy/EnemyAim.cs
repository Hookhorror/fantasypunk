using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAim : MonoBehaviour
{

    private float angle;
    private Vector2 lookDir;
    private GameObject target;

    void Start()
    {
        target = PlayerManager.instance.player;
    }

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
