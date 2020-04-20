using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomState : Room
{

    public Door[] doors;


    private void Start() {
        CloseDoors();
        CheckEnemies();
    }

    // Start is called before the first frame update


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
}
