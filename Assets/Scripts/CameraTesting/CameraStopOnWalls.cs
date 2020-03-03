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
    private float cameraPositionVertical;
    private float cameraPositionHorizontal;
    private bool cameraMoving = true;


    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        //cam.transform.position = rb.position;
        if (Vertical())
        {
            cam.transform.position = new Vector3(cameraPositionHorizontal, cameraPositionVertical, cam.transform.position.z);
        }
        if (Horizontal())
        {
            cam.transform.position = new Vector3(cameraPositionHorizontal, cameraPositionVertical, cam.transform.position.z);
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
        // TODO: if we're to continue with this remove hard coding
        if (rb.position.x < -5f || rb.position.x > 5f)
        {
            return false;
        }
        cameraPositionHorizontal = rb.position.x;
        return true;
    }

    private bool Vertical()
    {
        // TODO: if we're to continue with this remove hard coding
        if (rb.position.y < -6f || rb.position.y > 4f)
        {
            return false;
        }
        cameraPositionVertical = rb.position.y;
        return true;
    }


}
