using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : Objects
{
     void Start()
    {
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        clip = "Pot";
    }
}
