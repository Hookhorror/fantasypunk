using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHealth;
<<<<<<< HEAD
=======
    // TODO: implement better way of inflicting damage
    public float damageTaken;
    public bool hasDeathAnimation;
    public GameObject deathPrefab;
>>>>>>> e2cc1171fafc431dca9d2b0ed8d06bfe396424c8
    private float health;
    private bool dead = false;

    public bool Dead()
    {
        return dead;
    }




    void Awake()
    {
        SetHealthToMax();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Some testing
        // rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Projectile") && health >= 0)
        {

            var bullet = other.gameObject.GetComponent<Bullet>();
            TakeDamage(bullet.damage);
        }
    }

    private void SetHealthToMax()
    {
        health = maxHealth;
    }

    // TODO: Damagelogic has probably a better place somewhere else
    private void TakeDamage(float damage)
    {
        if (damage >= health)
        {
            Die();
        }
        else health -= damage;

    }

    private void Die()
    {
        dead = true;
        if (hasDeathAnimation)
        {
            Instantiate(deathPrefab, gameObject.transform.position, Quaternion.identity);
        }
        gameObject.SetActive(false);
        GetComponentInParent<RoomState>().CheckEnemies();
        // CheckEnemies();
        //Destroy(gameObject);
    }

    private void MoveLeftToRight()
    {

    }

}
