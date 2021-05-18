using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// [RequireComponent(typeof(Controller2D))]
[RequireComponent(typeof(Movement))]
public class Player : MonoBehaviour
{
	public float jumpHeight = 3;
	public float timeToJumpApex = .37f;
	public float moveSpeed = 6;
    public float attackRange;

    float accelerationTimeAirborne = .4f;
    float accelerationTimeGrounded = .1f;

    public float playerDirection;
    float gravity;
    float jumpVelocity;
    Vector2 velocity;
    float velocityXSmoothing;

	// Controller2D controller;
    Movement movement;
    RaycastController raycastControl;
    Attack attack;
    BoxCollider2D bc2d;

    void Start() 
    {

    	// controller = GetComponent<Controller2D>();
        raycastControl = GetComponent<RaycastController>();
        movement = GetComponent<Movement>();
        attack = GetComponent<Attack>();
        bc2d = GetComponent<BoxCollider2D>();
    	gravity = -(2 * jumpHeight / Mathf.Pow(timeToJumpApex, 2));
    	jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        playerDirection = 1;

        Bounds bounds = bc2d.bounds;
        attackRange = bounds.size.x;
        print(attackRange);
    }

    void OnEnable()
    {
        velocity = Vector2.zero;
    }

    void FixedUpdate() 
    {
        Move();
        // attack.CheckRange();
        if (attack == null) print("attack not found");
    }

    void Move()
    {

        bool isGrounded = movement.collisions.below;
        if (movement.collisions.above || isGrounded)
        {
            velocity.y = 0;
        }

        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), 
                                    Input.GetAxisRaw("Vertical"));

        playerDirection = (input.x != 0)? input.x: playerDirection;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = jumpVelocity;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            if (velocity.y > 0){
                velocity.y = velocity.y * 0.5f;
            }
        }

        float targetVelocityX = input.x * moveSpeed;
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, 
                                        ref velocityXSmoothing, 
                                        (isGrounded)?
                                        accelerationTimeGrounded:
                                        accelerationTimeAirborne); 
        velocity.y += gravity * Time.deltaTime;
        movement.Move(velocity * Time.deltaTime);
    }

}
