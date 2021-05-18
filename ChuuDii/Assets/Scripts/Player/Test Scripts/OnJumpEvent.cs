using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnJumpEvent : MonoBehaviour
{
    void OnEnable()
    {
    	TestMovementHandler.OnJump += JumpEvent;
    }

    void OnDisable()
    {
    	TestMovementHandler.OnJump -= JumpEvent;
    }

    static void JumpEvent(float velocity)
    {
    	print("Jumped with velocity " + velocity);
    }
}
