using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class breakable : Objects
{

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
}
