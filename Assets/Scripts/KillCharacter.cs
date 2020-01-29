using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCharacter : MonoBehaviour
{
    public GameObject character;
    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(character);
    }
}
