using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    public Camera cam;
    public Rigidbody2D rb;
    private Vector2 mousePos;
    private float angle;

    // Update is called once per frame
    void Update()
    {
        mousePos.x = cam.ScreenToWorldPoint(Input.mousePosition).x - rb.position.x;
        mousePos.y = cam.ScreenToWorldPoint(Input.mousePosition).y - rb.position.y;
        // mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg + 90f;
    }

    void FixedUpdate()
    {
        // Turns the aim
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

}
