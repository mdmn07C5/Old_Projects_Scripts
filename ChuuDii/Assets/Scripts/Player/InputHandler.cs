using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{

	public delegate void MovementHandler(float velocity);
	public static event MovementHandler OnMove;
	public static event MovementHandler OnJump;
	public static event MovementHandler OnCrouch;


	void Start()
	{
		print("eat shit");
	}

	public void OnPlayerMovementInput()
	{
		if (Input.GetKey(KeyCode.A)){
			if (OnMove != null) 
			{
				OnMove(0.5f);
			}
		}
		if (OnJump != null) 
		{
			OnJump(0.4f);
		}
		if (OnCrouch != null) 
		{
			OnCrouch(0.2f);
		}
	}

}
