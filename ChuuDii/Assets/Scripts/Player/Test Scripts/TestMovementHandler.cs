using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovementHandler : MonoBehaviour
{ 
	public delegate void MovementHandler(float velocity);
	public static event MovementHandler OnMove;
	public static event MovementHandler OnJump;


	void Start()
	{
		print("eat shit");
	}

	void Update()
	{
		OnPlayerMovementInput();
	}

	public void OnPlayerMovementInput()
	{
		if (Input.GetButton("Jump"))
		{
			if (OnJump != null)
			{
				OnJump(0.3f);
			}
		}
		if (Input.GetButton("Horizontal"))
		{
			if (OnMove != null) 
			{
				OnMove(0.5f);
			}
		}

	}
}
