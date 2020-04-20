using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proto2buttons : MonoBehaviour
{
    private Shooting shooting;
    private Weapon weapon;
    private FirePattern firePattern;

    // Start is called before the first frame update
    void Start()
    {
        shooting = GetComponent<Shooting>();
        weapon= GetComponent<Weapon>();
        firePattern = weapon.firePattern;
    }

    // Update is called once per frame
    void Update()
    {   
        // preset 1
        if (Input.GetButton("Fire2"))
        {
            shooting.Reload();
            firePattern.angles = new float[] { 0 };

            weapon.fireRate = 0.05;
            weapon.magazine = 7;
            weapon.reload = 1.0;
            weapon.bulletForce = 20;
        }

        // preset 2
        if (Input.GetButton("Fire3"))
        {
            shooting.Reload();
            firePattern.angles = new float[] { 0, 10, 20, -10, -20 };

            weapon.fireRate = 0.5;
            weapon.magazine = 3;
            weapon.reload = 2.0;
            weapon.bulletForce = 10;
        }
    }
}
