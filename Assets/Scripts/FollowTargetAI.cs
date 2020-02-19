using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTargetAI : MonoBehaviour
{
    public float speed;
    public Transform[] checkpoints;
    public Rigidbody2D target;
    public float range;

    private int randomCheckpoint;

    void Awake()
    {
        // Gizmos.DrawWireSphere(new Vector3(0, 0, 0), 2);
    }
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
        float distanceToTarget = Vector2.Distance(transform.position
                                                , target.transform.position);

        if (distanceToTarget <= range)
        {
            transform.position = Vector2.MoveTowards(transform.position
                              , target.position
                              , speed * Time.deltaTime);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
