using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndDoor : Room
{

    

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other) {

        if(other.CompareTag("Player") && enemiesInTheRoom==false)
        {
            SceneManager.LoadScene("Victory");
        }
        
    }



}
