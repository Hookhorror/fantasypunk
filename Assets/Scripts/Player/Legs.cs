using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Legs : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Animator animator;
    private Vector2 movement;
    private GameObject player;
    // Vector2 lastMovement;
    // private bool idle = true;

    void Start()
    {
        player = PlayerManager.instance.player;
        // gameObject.GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);
        // player.GetComponent<SpriteRenderer>().color = new Color(0,0,0,255);
    }

    // Update is called once per frame
    void Update()
    {
        // Moving
        // movement.x = Input.GetAxisRaw("Horizontal");
        // movement.y = Input.GetAxisRaw("Vertical");

        // Moving direction
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Animations based on moving direction and speed
        animator.SetFloat("MovingHorizontal", movement.x);
        animator.SetFloat("MovingVertical", movement.y);
        animator.SetFloat("MovingSpeed", movement.sqrMagnitude);

        if (player.GetComponent<PlayerHP>().dead)
        {
            MakeOpaque();
        }

        animator.SetBool("Dead", player.GetComponent<PlayerHP>().dead);
        // animator.SetInteger("Health", player.GetComponent<PlayerHP>().currentHP);
    }

    internal void MakeOpaque()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);
    }
}
