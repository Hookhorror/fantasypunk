﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [Header("Position Variables")]
    public Transform target;
    public float smoothing;
    public Vector2 maxP;
    public Vector2 minP;
/**
    [Header("Position Reset")]
    public VectorValue camMax;
    public VectorValue camMin;


    private void Start() {
        maxP = camMax.initialValue;
        minP = camMin.initialValue;
        transform.position = new Vector3(target.position.x, target.position.y, target.position.z);

    }
*/
    // Update is called once per frame
    void LateUpdate()
    {
        if(transform.position != target.position)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            targetPosition.x = Mathf.Clamp(targetPosition.x, minP.x, maxP.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minP.y, maxP.y);

            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }
    }
    
}
