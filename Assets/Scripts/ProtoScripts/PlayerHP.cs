using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{

    public int maxHP = 100;
    public int currentHP;

    public HPBar hpBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
        hpBar.SetMaxHP(maxHP);
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D other)
    {
    if(other.gameObject.CompareTag("Projectile") || other.gameObject.CompareTag("Enemy")){
           TakeDMG(10); 
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Projectile") || other.gameObject.CompareTag("Enemy")){
           TakeDMG(10); 
        }
    }

    void TakeDMG(int dmg)
    {
        currentHP -= dmg;
        hpBar.SetHP(currentHP);
    }
}
