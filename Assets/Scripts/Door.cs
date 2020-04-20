using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Door : Interactable
{
    public Vector2 camChange;

    public Vector3 playerChange;

    public bool active = true;
    private CameraMovement cam;
    public bool needText;
    public string placeName;
    public GameObject text;
    public Text placeText;

    public BoxCollider2D box;


    public void Open()
    {
        try
        {
            active = true;
            box.enabled = true;
        }
        catch (System.Exception e)
        {
            
            throw e;
        }
        
    }

    public void Close()
    {
        try
        {
            active = false;
            box.enabled = false;
        }
        catch (System.Exception ex)
        {
            
            throw ex;
        }
       
    }

    public void OnTriggerEnter2D(Collider2D other) 
    {
            if(other.CompareTag("Player") && active==true)
            {
                cam.minP += camChange;
                cam.maxP += camChange;
                other.transform.position += playerChange;
                if(needText)
                {
                    StartCoroutine(placeNameCo());
                }
            }
    }

    

    protected IEnumerator placeNameCo()
    {
        text.SetActive(true);
        placeText.text = placeName;
        yield return new WaitForSeconds(4f);
        text.SetActive(false);
    }
}