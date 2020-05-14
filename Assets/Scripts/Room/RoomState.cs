using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RoomState : Room
{

    public Door[] doors;
    public EnemyMarker enemyMarker;
    private bool wait = true;

    private void Start() {
        CloseDoors();
        CheckEnemies();
    }

   private void Update() 
   {
       /**
       if(wait)
       {
           StartCoroutine(WaitCo());
       }
        */
       CheckEnemies();
       
   }


    public void CheckEnemies()
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

    public void CloseDoors()
    {
        enemyMarker.SetMarkerOn();
        enemiesInTheRoom = true;
        Debug.Log("Closing Doors");
        for (int i = 0; i < doors.Length; i++)
        {
            doors[i].Close();
        }
    }

        protected void OpenDoors()
    {
        enemyMarker.SetMarkerOff();
        enemiesInTheRoom = false;
        Debug.Log("Opening Doors");
        for (int i = 0; i < doors.Length; i++)
        {
            doors[i].Open();
        }
    }

    IEnumerator WaitCo()
    {
        Debug.Log("CheckEnemies Wait Corona");
        wait = false;
        yield return new WaitForSeconds(5f);
        Debug.Log("CheckEnemies Wait stopped, checks now");
        CheckEnemies();
        wait = true;
    }
}
