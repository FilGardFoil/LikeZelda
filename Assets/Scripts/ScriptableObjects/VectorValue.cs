using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

[CreateAssetMenu]
public class VectorValue : ScriptableObject, ISerializationCallbackReceiver
{
    public Vector2 initialValue;
    public Vector2 defaultValue;
    public Vector2 camInitialMaxValue;
    public Vector2 camDefaultMaxValue;
    public Vector2 camInitialMinValue;
    public Vector2 camDefaultMinValue;

    public void OnAfterDeserialize()
    {
        initialValue = defaultValue;
        camInitialMaxValue = camDefaultMaxValue;
        camInitialMinValue = camDefaultMinValue;
    }

    public void OnBeforeSerialize()
    {

    }
}
