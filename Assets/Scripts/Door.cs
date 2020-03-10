using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Vector2 camChange;

    public Vector3 playerChange;
    private CameraMovement cam;

    private void Start() 
    {
        cam = Camera.main.GetComponent<CameraMovement>();
    }

    private void Update() 
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            cam.minP += camChange;
            cam.maxP += camChange;
            other.transform.position += playerChange;
        }
    }
}
