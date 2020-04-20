using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Door : MonoBehaviour
{
    public Vector2 camChange;

    public Vector3 playerChange;

    public bool active = true;
    private CameraMovement cam;
    public bool needText;
    public string placeName;
    public GameObject text;
    public Text placeText;

    private BoxCollider2D box;

    private void Start() 
    {
        cam = Camera.main.GetComponent<CameraMovement>();
    }

    private void Update() 
    {
        
    }

    public void Open()
    {
        box.enabled = true;
    }

    public void Close()
    {
        box.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other) 
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

    private IEnumerator placeNameCo()
    {
        text.SetActive(true);
        placeText.text = placeName;
        yield return new WaitForSeconds(4f);
        text.SetActive(false);
    }
}