using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour
{

    public GameObject canvas;
    // Start is called before the first frame update
 void Start()
 {
 }
 void Update()
     {
         if (Input.GetKeyDown(KeyCode.R))
         {
              SceneManager.LoadScene( SceneManager.GetActiveScene().name );
         }

        if (Input.GetKeyDown(KeyCode.Q))
         {
             if(canvas.activeSelf == false)
             {
                 canvas.SetActive(true);
             }
             else canvas.SetActive(false);
            
         }




     }
}
