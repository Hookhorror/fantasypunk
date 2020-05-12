using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUI : MonoBehaviour
{

    public GameObject arImage;
    public GameObject shotgunImage;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire2"))
        {
            SetAR();
        }

        if(Input.GetButton("Fire3"))
        {
            SetShotgun();
        }
    }

    public void SetAR()
    {
        arImage.SetActive(true);
        shotgunImage.SetActive(false);
    }

    public void SetShotgun()
    {
        arImage.SetActive(false);
        shotgunImage.SetActive(true);
    }
}
