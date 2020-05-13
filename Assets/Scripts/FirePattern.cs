using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePattern : MonoBehaviour
{
    public float[] angles;

    // combines existing angles with new angles
    public float[] combine(float[] newangles)
    {
        float[] result = new float[(angles.Length*newangles.Length)];
        int i = 0;
        foreach(float f1 in angles)
        {
            foreach(float f2 in newangles)
            {
                Debug.Log(f1 + ", " + f2);
                result[i] = f1 + f2;
                Debug.Log(result[i]);
                i++;
            }
        }
        angles = result;
        return result;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
