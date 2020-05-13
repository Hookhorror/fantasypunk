using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Camera cam;
    //public Animator legs;
    //public Animator torso;
    // public Animator animator;
    Vector2 movement;
    Vector2 mousePos;

    private GameObject player;
    // private GameObject target;
    // private Camera cam;

    void Start()
    {
        player = PlayerManager.instance.player;
        // target = PlayerManager.instance.player;
        // cam = CameraManager.instance.cam;
    }


    // Update is called once per frame
    void Update()
    {
        // Get player input for movement
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Normalizing movement direction prevents movement being faster diagonally
        movement = movement.normalized;

        // animator.SetFloat("MovementHorizontal", movement.x);
        // animator.SetFloat("MovementVertical", movement.y);
        // animator.SetFloat("MovementSpeed", movement.sqrMagnitude);

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        // animator.SetFloat("FacingHorizontal", mousePos.x);
        // animator.SetFloat("FacingVertical", mousePos.y);
    }

    void FixedUpdate()
    {
        // rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        if (!player.GetComponent<PlayerHP>().dead)
        {
            rb.transform.position = Vector3.Lerp(rb.position
                                    , rb.position + movement * moveSpeed * Time.fixedDeltaTime
                                    , 0.5f);
        }
        // Vector2 lookDir = mousePos - rb.position;
        // float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        // rb.rotation = angle;
    }
}
