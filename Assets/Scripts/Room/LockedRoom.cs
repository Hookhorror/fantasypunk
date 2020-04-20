using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedRoom : DungeonRoom
{
    public Door[] doors;


    // Start is called before the first frame update


    protected void CheckEnemies()
    {
        for(int i = 0; i < enemies.Length; i++)
        {
            if(enemies[i].gameObject.activeInHierarchy)
            {
                return;
            }
        }
        OpenDoors();
    }

    protected void CloseDoors()
    {
        for (int i = 0; i < doors.Length; i++)
        {
            doors[i].Close();
        }
    }

    
    protected void OpenDoors()
    {
        for (int i = 0; i < doors.Length; i++)
        {
            doors[i].Open();
        }
    }

    public override void OnTriggerEnter2D(Collider2D other) 
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
        CloseDoors();
    }


    public override void OnTriggerExit2D(Collider2D other)
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

}
