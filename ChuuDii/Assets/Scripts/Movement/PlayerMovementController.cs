using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CollisionDetector))]
public class PlayerMovementController : MonoBehaviour
{
    // Start is called before the first frame update
	CollisionDetector collider;
    [SerializeField]
	float gravity;
	float velocityXSmoothing;
	Vector2 directionalInput;
	

    public Vector2 velocity;
	public float targetVelocityX;
	public PlayerStats playerStats;

    void Start()
    {
        collider = GetComponent<CollisionDetector>();

        //TODO: put this somewhere else for variable gravity
        gravity = -(2 * playerStats.jumpHeight) / Mathf.Pow(playerStats.timeToJumpApex, 2);
    	// print(gravity);
    	CalculateVelocity();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        collider.UpdateRaycastOrigins();
        collider.collisions.Reset();
        CalculateVelocity();
        // velocity.x = 0;
        collider.HorizontalCollisions(ref velocity);
        collider.VerticalCollisions(ref velocity);
        transform.parent.transform.Translate(velocity);
    }

    void CalculateVelocity()
    {
  //   	float targetVelocityX = directionalInput.x * playerStats.moveSpeed;
		velocity.x = Mathf.SmoothDamp (velocity.x, 
									   targetVelocityX, 
									   ref velocityXSmoothing, 
									   (collider.collisions.below)? 
									    playerStats.accelerationTimeGrounded:
									    playerStats.accelerationTimeAirborne);
		print(velocity.x);
		// velocity.y += gravity * Time.deltaTime;
		velocity.y += gravity * Time.fixedDeltaTime;
    }

    void SetDirectionalInput(float horizontalInput, float verticalInput)
    {
    	directionalInput = new Vector2(horizontalInput, verticalInput);
    }

    void MovePlayer()
    {

    }
}
