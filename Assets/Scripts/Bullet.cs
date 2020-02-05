using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Spawns the hit effect when bullet collides
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        // Destroys the effect after given time
        Destroy(effect, 1);
        Destroy(gameObject);
        Destroy(gameObject, 3);
    }
}
