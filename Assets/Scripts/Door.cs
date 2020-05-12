using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Door : MonoBehaviour
{
    public Vector2 camChange;

    public Vector2 playerChange;


    public bool active = true;
    private CameraMovement cam;
    public bool needText;
    public string placeName;
    public GameObject text;
    public Text placeText;

   // protected BoxCollider2D box;

    private void Start() 
    {
        cam = Camera.main.GetComponent<CameraMovement>();
       // box = GetComponent<BoxCollider2D>();
    }

    private void Update() 
    {
        
    }

    public void Open()
    {
        active = true;
        //box.enabled = true;
    }

    public void Close()
    {
        active = false;
       // box.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player") && active==true)
        {
            BoxCollider2D bc = other.GetComponent<BoxCollider2D>();
            bc.enabled = false;
            cam.minP += camChange;
            cam.maxP += camChange;
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            rb.position += playerChange;
            bc.enabled = true;
            if(needText)
            {
                StartCoroutine(placeNameCo());
            }
        }
    }

    private IEnumerator placeNameCo()
    {
        if(text != null)
        {
            text.SetActive(true);
            placeText.text = placeName;
            yield return new WaitForSeconds(4f);
            text.SetActive(false); 
        }

    }
}