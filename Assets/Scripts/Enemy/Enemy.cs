using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHealth;
    // TODO: implement better way of inflicting damage
    public float damageTaken;
    public bool hasDeathAnimation;
    public GameObject deathPrefab;
    public GameObject explosionPrefab;
    public GameObject goo2;
    public GameObject goo2Splitted;
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
        dead = true;
        if (hasDeathAnimation)
        {
            Instantiate(explosionPrefab, gameObject.transform.position, Quaternion.identity);
            Instantiate(deathPrefab, gameObject.transform.position, Quaternion.identity);
        }
        if (gameObject.name == goo2.name)
        {
            Split();
        }

        gameObject.SetActive(false);
        // GetComponentInParent<RoomState>().CheckEnemies();
        // CheckEnemies();
        //Destroy(gameObject);
    }

    private void Split()
    {
        Vector3 spawn1 = new Vector3(gameObject.transform.position.x + 0.5f
                                   , gameObject.transform.position.y + 0.5f
                                   , gameObject.transform.position.z);
        Vector3 spawn2 = new Vector3(gameObject.transform.position.x - 0.5f
                                   , gameObject.transform.position.y + 0.5f
                                   , gameObject.transform.position.z);
        Vector3 spawn3 = new Vector3(gameObject.transform.position.x + 0.5f
                                   , gameObject.transform.position.y - 0.5f
                                   , gameObject.transform.position.z);
        Vector3 spawn4 = new Vector3(gameObject.transform.position.x - 0.5f
                                   , gameObject.transform.position.y - 0.5f
                                   , gameObject.transform.position.z);                                   
        
        Instantiate(goo2Splitted, spawn1, Quaternion.identity);
        Instantiate(goo2Splitted, spawn2, Quaternion.identity);
        Instantiate(goo2Splitted, spawn3, Quaternion.identity);
        Instantiate(goo2Splitted, spawn4, Quaternion.identity);
    }

    private void MoveLeftToRight()
    {

    }

}
