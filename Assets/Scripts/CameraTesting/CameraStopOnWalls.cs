using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStopOnWalls : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Camera cam;
    Vector2 movement;
    Vector2 mousePos;
    //private bool cameraFollow = true;
    //public GameObject wallN;
    //public GameObject wallS;
    //public GameObject wallW;
    //public GameObject wallE;
    private float cameraStopVertical;
    private float cameraStopHorizontal;


    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        // cam.transform.position = rb.position;
        if (Vertical())
        {
            cam.transform.position = new Vector3(rb.position.x, cameraStopVertical, cam.transform.position.z);
        }
        if (Horizontal())
        {
            cam.transform.position = new Vector3(rb.position.x, cameraStopHorizontal, cam.transform.position.z);
        }
        
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;

        // cam.transform.
        
    }

    private bool Horizontal()
    {
        if (rb.position.x < -5f || rb.position.x > 5f) 
        {
            cameraStopHorizontal = cam.transform.position.x;
            return false;
        }
        return true;
    }

    private bool Vertical()
    {
        if (rb.position.y < -4f || rb.position.y > 4f) 
        {
            cameraStopVertical = cam.transform.position.y;
            return false;
        }
        return true;
    }


}
