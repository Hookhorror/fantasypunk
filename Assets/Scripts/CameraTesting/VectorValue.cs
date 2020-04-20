using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class VectorValue : ScriptableObject, ISerializationCallbackReceiver
{
    [Header("Running")]
    public Vector2 initialValue;
    [Header("Default")]
    public Vector2 defaultValue;

    public void OnAfterDeserialize()
    {
        initialValue = defaultValue;
    }

    public void OnBeforeSerialize()
    {
        
    }
}
