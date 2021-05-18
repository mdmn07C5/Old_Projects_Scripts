using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TestMovementEvents : ScriptableObject
{
	void OnEnable()
	{
		TestMovementHandler.OnMove += MoveEvent;
		TestMovementHandler.OnJump += JumpEvent;
	}

	void OnDisable()
	{
		TestMovementHandler.OnMove -= MoveEvent;
		TestMovementHandler.OnJump -= JumpEvent;
	}

	void MoveEvent(float velocity)
	{
		Debug.Log("Moved with velocity " + velocity);
	}

	void JumpEvent(float velocity)
	{
		Debug.Log("Jumped with velocity " + velocity);
	}
}
