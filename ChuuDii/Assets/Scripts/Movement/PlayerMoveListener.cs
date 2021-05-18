using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerMoveListener", menuName = "Custom Assets/New Player Move Listener")]
public class PlayerMoveListener : ScriptableObject
{
	public PlayerStats playerStats;
	public float speed;
	// public PlayerMovementController pmc;

	float velocityXSmoothing;
    // Start is called before the first frame update
    void OnEnable()
    {
        // PlayerInputHandler.OnMove += MovePlayer;
    }

    // Update is called once per frame
    void OnDisable()
    {
        // PlayerInputHandler.OnMove -= MovePlayer;
    }

    void MovePlayer(GameObject go)
    {
    	float horizontalMovement = Input.GetAxisRaw("Horizontal") * playerStats.moveSpeed;
    	PlayerMovementController pmc = go.GetComponentInChildren<PlayerMovementController>();

    	pmc.targetVelocityX = horizontalMovement;

    }
}
