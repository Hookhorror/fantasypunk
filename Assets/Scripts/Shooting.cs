using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public AudioClip soundEffect;

    public float bulletForce = 20f;
    // Update is called once per frame

    private AudioSource source;

    void Awake()
    {

        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            // Just for fun :D
            // for (int i = 0; i < 100; i++)
            // {
            //     Shoot();
            // }
            Shoot();
        }
    }

    void Shoot()
    {
        source.PlayOneShot(soundEffect);
        // Spawn a bullet
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        // Adds rigidbody to the bullet
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        // Makes the bullet fly in simple
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
