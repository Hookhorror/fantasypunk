using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class breakable : MonoBehaviour
{

    private Animator animator;

    private BoxCollider2D boxCollider;

    public AudioClip[] soundEffect;
    private AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    
    private void Awake() {
        source = GetComponent<AudioSource>();
    }

    public void Smash()
    {
        //try
        //{
            animator.SetBool("smash", true);
            source.PlayOneShot(soundEffect[UnityEngine.Random.Range(0, soundEffect.Length)]);
            StartCoroutine(breakCo());
            //boxCollider.enabled = false;
       // }
        //catch(NullReferenceException ex)
        //{
           // Debug.Log("animator not set");  
           // Debug.Log(ex);  
        //}
        
    }

    public IEnumerator breakCo()
    {
        boxCollider.enabled = false;
        yield return new WaitForSecondsRealtime(5);
        boxCollider.enabled = true;
        this.gameObject.SetActive(false);
    }
}
