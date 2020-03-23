using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Animator animator;
    Vector2 movement;


    // Update is called once per frame
    void Update()
    {
        // Moving
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Moving direction
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Animations based on moving direction and speed
        animator.SetFloat("MovingHorizontal", movement.x);
        animator.SetFloat("MovingVertical", movement.y);
        animator.SetFloat("MovingSpeed", movement.sqrMagnitude);
    }
}
