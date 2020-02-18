using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    public Transform[] checkpoints;
    public Rigidbody2D target;

    private int randomCheckpoint;
    // Start is called before the first frame update
    void Start()
    {
        randomCheckpoint = Random.Range(0, checkpoints.Length);
    }

    void Update()
    {
        // transform.position = Vector2.MoveTowards(transform.position
        //                    , checkpoints[randomCheckpoint].position
        //                    , speed * Time.deltaTime);
        transform.position = Vector2.MoveTowards(transform.position
                           , target.position
                           , speed * Time.deltaTime);
    }
}
