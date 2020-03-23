using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Facing : MonoBehaviour
{
    public Camera cam;
    public Animator animator;
    private Vector2 mousePos;

    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        animator.SetFloat("FacingHorizontal", mousePos.x);
        animator.SetFloat("FacingVertical", mousePos.y);
    }
}
