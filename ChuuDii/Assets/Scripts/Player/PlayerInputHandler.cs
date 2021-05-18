using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    // Start is called before the first frame update
	// public GameObject player = ;

	public delegate void MovementHandler(GameObject go);
	public static event MovementHandler OnMove;
	public static event MovementHandler OnJump;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveInput();
    }

    public void PlayerMoveInput()
    {
    	if (Input.GetButton("Horizontal"))
		{
			Debug.Log(Input.GetAxisRaw("Horizontal"));
    		if (OnMove != null)
    		{
    			OnMove(gameObject);
    		}
		}

		if (Input.GetButton("Jump"))
		{
			if (OnJump != null)
			{
				OnJump(gameObject);
			}
		}
    }

    public void PlayerAttackInput() { }

    public void PlayerInteractInput() { }

    public void PlayerMenuInput() { }
}
