using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public Animator animator;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = PlayerManager.instance.player;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Dead", player.GetComponent<PlayerHP>().dead);
    }
}
