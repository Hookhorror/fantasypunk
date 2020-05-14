using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objects : MonoBehaviour
{

    protected Animator animator;

    protected string clip;

    protected BoxCollider2D boxCollider;
    protected AudioSource source;

    public GameObject shadow;

    void Start()
    {
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        source = GetComponent<AudioSource>();
    }

    public void Smash()
    {
        boxCollider.enabled = false;
        shadow.SetActive(false);
        animator.SetBool("smash", true);
        source.Play();
        
        StartCoroutine(breakCo());
    
    }

    public IEnumerator breakCo()
    {
        boxCollider.enabled = false;
        yield return new WaitForSeconds(1F);
        boxCollider.enabled = true;
        this.gameObject.SetActive(false);
    }
}

