using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RoomState : Room
{

    public Door[] doors;
    public EnemyMarker enemyMarker;

    private void Start() {
        CloseDoors();
        CheckEnemies();
    }

   private void Update() 
   {
       StartCoroutine(WaitCo());
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

    protected void CloseDoors()
    {
        enemyMarker.SetMarkerOn();
        for (int i = 0; i < doors.Length; i++)
        {
            doors[i].Close();
        }
    }

        protected void OpenDoors()
    {
        enemyMarker.SetMarkerOff();
        for (int i = 0; i < doors.Length; i++)
        {
            doors[i].Open();
        }
    }

    IEnumerator WaitCo()
    {
        Debug.Log("CheckEnemies Wait Corona");
        yield return new WaitForSeconds(5f);
        Debug.Log("CheckEnemies Wait stopped, checks now");
        CheckEnemies();
        
    }
}
