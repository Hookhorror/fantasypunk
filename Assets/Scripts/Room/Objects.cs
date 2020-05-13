using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objects : MonoBehaviour
{

    protected Animator animator;

    protected string clip;

    protected BoxCollider2D boxCollider;

    protected CapsuleCollider2D capsuleCollider;

    void Start()
    {
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    public void Smash()
    {
        animator.SetBool("smash", true);
        // AudioManager.instance.Play(clip);
        StartCoroutine(breakCo());
        if (capsuleCollider != null)
        {
            capsuleCollider.enabled = false;
        }
    }

    public IEnumerator breakCo()
    {
        boxCollider.enabled = false;
        yield return new WaitForSeconds(1F);
        boxCollider.enabled = true;
        this.gameObject.SetActive(false);
    }
}

