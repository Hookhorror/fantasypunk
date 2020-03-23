using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public Enemy[] enemies;
    public barrel[] barrels;

    public virtual void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            // Activates
            // Enemies
            for (int i = 0; i < enemies.Length; i++)
            {
                ChangeActivation(enemies[i], true);
            }

            
            // barrels
             for (int i = 0; i < barrels.Length; i++)
            {
                ChangeActivation(barrels[i], true);
            }
            
        }
    }

    public virtual void OnTriggerExit2D(Collider2D other)
    {
        // Deactivation
            if(other.CompareTag("Player") && !other.isTrigger)
        {
            // Enemies
            for (int i = 0; i < enemies.Length; i++)
            {
                ChangeActivation(enemies[i], false);
            }

            
            // barrels
             for (int i = 0; i < barrels.Length; i++)
            {
                ChangeActivation(barrels[i], false);
            }
            
        }
    }

    void ChangeActivation(Component component, bool activation)
    {
        component.gameObject.SetActive(activation);
    }

}
