using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;

    public Weapon weapon;
    public Texture2D cursorReload;
    private Bullet bulletPrefab;
    private FirePattern firePattern;
    private float bulletForce;
    private AudioClip soundEffect;
    private AudioSource source;
    private double fireTimer = 0;
    private int mag;
    private double reloadTimer;
    private CursorMode cursorMode = CursorMode.Auto;

    void Awake()
    {
        source = GetComponent<AudioSource>();
        bulletPrefab = weapon.bullet;
        soundEffect = weapon.sound;
        bulletForce = weapon.bulletForce;
        mag = weapon.magazine;
        firePattern = weapon.firePattern;
    }

    // Update is called once per frame
    void Update()
    {
        fireTimer -= Time.deltaTime;
        reloadTimer -= Time.deltaTime;

        if (reloadTimer <= 0)
        {
            Cursor.SetCursor(null, Vector2.zero, cursorMode);
        }

        if (reloadTimer<=0 && fireTimer<=0 && Input.GetButton("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        source.PlayOneShot(soundEffect);
        Vector3 forward = firePoint.up * bulletForce;

        for (int i = 0; i < firePattern.angles.Length; i++)
        {
            // Spawn a bullet
            Bullet bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            // Adds rigidbody to the bullet
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            // Makes the bullet fly in simple
            rb.AddForce(rotateVector(forward, firePattern.angles[i]), ForceMode2D.Impulse);
        }

        fireTimer = weapon.fireRate;
        mag--;
        if (mag <= 0) Reload();
    }

    public void Reload()
    {
        Cursor.SetCursor(cursorReload, Vector2.zero, cursorMode);
        reloadTimer = weapon.reload;
        mag = weapon.magazine;
    }

    private static Vector3 rotateVector(Vector3 v, float degrees)
    {
        float sin = Mathf.Sin(degrees * Mathf.Deg2Rad);
        float cos = Mathf.Cos(degrees * Mathf.Deg2Rad);

        float tx = v.x;
        float ty = v.y;
        v.x= (cos * tx) - (sin * ty);
        v.y = (sin * tx) + (cos * ty);
        return v;
    }
}
