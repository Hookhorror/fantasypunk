using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public double fireRate;
    public int magazine;
    public double reload;
    public float bulletForce;

    public Bullet bullet;
    public AudioClip sound;
    public FirePattern firePattern;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
