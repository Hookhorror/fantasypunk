using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public Enemy[] enemies;
    public Object[] objects;

    public bool enemiesInTheRoom;

    /**
    public virtual void OnTriggerEnter2D(Collider2D other) 
    {
        if((other.CompareTag("Player") && !other.isTrigger))
        {
            // Activates
            // Enemies
            for (int i = 0; i < enemies.Length; i++)
            {
                ChangeActivation(enemies[i], true);
            }

            
            // breakabbles
             for (int i = 0; i < breakables.Length; i++)
            {
                ChangeActivation(breakables[i], true);
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

            
            // breakables
             for (int i = 0; i < breakables.Length; i++)
            {
                ChangeActivation(breakables[i], false);
            }
            
        }
    }

    protected void ChangeActivation(Component component, bool activation)
    {
        component.gameObject.SetActive(activation);
    }
    */
}
