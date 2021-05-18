using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEvent : MonoBehaviour
{
	public PlayerStats playerStats;

    void OnEnable()
    {
        PlayerInputHandler.OnMove += MovePlayer;
    }

    // Update is called once per frame
    void OnDisable()
    {
        PlayerInputHandler.OnMove -= MovePlayer;
    }

    void MovePlayer(GameObject go)
    {
    	float horizontalMovement = Input.GetAxisRaw("Horizontal") * playerStats.moveSpeed;
    	PlayerMovementController pmc = go.GetComponentInChildren<PlayerMovementController>();

    	pmc.targetVelocityX = horizontalMovement;

    }
}
