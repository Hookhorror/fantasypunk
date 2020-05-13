using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Pot : Objects
{
    

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        clip = "Pot";
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
