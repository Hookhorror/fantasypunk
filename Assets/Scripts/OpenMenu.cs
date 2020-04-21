using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenu : MonoBehaviour
{
    public Canvas canvas;

    void Update()
     {
         if (Input.GetKeyDown(KeyCode.Escape))
         {
              canvas.enabled = true;
         }
     }

    
}
