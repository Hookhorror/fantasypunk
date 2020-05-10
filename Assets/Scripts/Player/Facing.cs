using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Facing : MonoBehaviour
{
    public Camera cam;
    public Animator animator;
    public Rigidbody2D rb;
    private Vector2 mousePos;
    private GameObject player;

    void Start()
    {
        player = PlayerManager.instance.player;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos.x = cam.ScreenToWorldPoint(Input.mousePosition).x - rb.position.x;
        mousePos.y = cam.ScreenToWorldPoint(Input.mousePosition).y - rb.position.y;

        animator.SetFloat("FacingHorizontal", mousePos.x);
        animator.SetFloat("FacingVertical", mousePos.y);

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
