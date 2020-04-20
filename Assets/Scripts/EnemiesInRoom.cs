using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesInRoom : Observer
{

    public Door[] doors;
    // public SignalListener enemyUpdate;
    // Start is called before the first frame update

        public override void OnTriggerEnter2D(Collider2D other) 
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

            
            // barrels
             for (int i = 0; i < barrels.Length; i++)
            {
                ChangeActivation(barrels[i], false);
            }
            
        }
    }

    public void ChangeActivation(Component component, bool activation)
    {
        component.gameObject.SetActive(activation);
    }


    public void CheckEnemies()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            if(enemies[i].gameObject.activeInHierarchy)
            {
                return;
            }
        }
        OpenDoors();
    }

    public void CloseDoors()
    {
        for(int i = 0; i < doors.Length; i++)
        {
           // doors[i].Close();
        }
    }

    public void OpenDoors()
    {
                for(int i = 0; i < doors.Length; i++)
        {
           // doors[i].Open();
        }
    }
}
