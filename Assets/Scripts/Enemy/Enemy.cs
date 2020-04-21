using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected float maxHealth;
    // TODO: implement better way of inflicting damage
    protected float damageTaken;
    private float health;


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
            health -= damageTaken;
            if (health <= 0)
            {
                Die();
            }
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
        gameObject.SetActive(false);
        GetComponentInParent<RoomState>().CheckEnemies();
        // CheckEnemies();
        //Destroy(gameObject);
    }

    private void MoveLeftToRight()
    {

    }

}
