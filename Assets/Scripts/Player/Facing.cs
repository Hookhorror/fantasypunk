using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Facing : MonoBehaviour
{
    public Camera cam;
    public Animator animator;
    public Rigidbody2D rb;
    private Vector2 mousePos;

    // Update is called once per frame
    void Update()
    {
        mousePos.x = cam.ScreenToWorldPoint(Input.mousePosition).x - rb.position.x;
        mousePos.y = cam.ScreenToWorldPoint(Input.mousePosition).y - rb.position.y;

        animator.SetFloat("FacingHorizontal", mousePos.x);
        animator.SetFloat("FacingVertical", mousePos.y);
    }
}
