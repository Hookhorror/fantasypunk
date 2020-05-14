using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicPot : Objects
{

    public float[] angles;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerHP php = other.gameObject.GetComponent<PlayerHP>(); ;
            if(php != null)
            {
                php.maxHP += 70;
                php.currentHP = php.maxHP;
            }

            Weapon w = other.gameObject.GetComponent<Weapon>();
            if (w != null)
            {
                w.firePattern.combine(angles);
                //Debug.Log(w.firePattern.angles.Length);
                w.fireRate *= 2.5;
                w.magazine += 2;
                w.reload *= 1.5;
            }
        }
        other.gameObject.GetComponent<Shooting>().Reload();
        this.Smash();
    }
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
