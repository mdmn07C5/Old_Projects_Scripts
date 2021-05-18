using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [CreateAssetMenu()]
public class OnMoveEvent : ScriptableObject
{
    void OnEnable()
    {
    	TestMovementHandler.OnMove += MoveEvent;
    }

    void OnDisable()
    {
    	TestMovementHandler.OnMove -= MoveEvent;
    }

    static void MoveEvent(float velocity)
    {
    	Debug.Log("Moved with velocity " + velocity);
    }
}
