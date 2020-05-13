using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objects : MonoBehaviour
{

    protected Animator animator;

    protected string clip;

    protected BoxCollider2D boxCollider;

    void Start()
    {
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    public void Smash()
    {
        animator.SetBool("smash", true);
        //AudioManager.instance.Play(clip);
        StartCoroutine(breakCo());
        boxCollider.enabled = false;
    
    }

    public IEnumerator breakCo()
    {
        boxCollider.enabled = false;
        yield return new WaitForSeconds(1F);
        boxCollider.enabled = true;
        this.gameObject.SetActive(false);
    }
}

