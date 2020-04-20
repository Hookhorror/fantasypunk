using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedRoom : DungeonRoom
{
    public Door[] doors;


    // Start is called before the first frame update
    public void Start() {
        OpenDoors();
    }

    public void CheckEnemies()
    {
       if(EnemiesActive() == 1)
       {
            OpenDoors();
       }
        
    }

    public int EnemiesActive()
    {
        int activeEnemies = 0;
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i].gameObject.activeInHierarchy)
            {
                activeEnemies++;
            }
        }
        return activeEnemies;
        
    }

    public void CloseDoors()
    {
        for (int i = 0; i < doors.Length; i++)
        {
            doors[i].Close();
        }
    }

    
    public void OpenDoors()
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
        CloseDoors();
    }

}
