using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerPlayerController : PhysicsObject
{


	public float jumpTakeOffSpeed = 7;
	public float maxSpeed = 7;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame

    protected override void ComputeVelocity()
    {
    	Vector2 move = Vector2.zero;

    	move.x = Input.GetAxis("Horizontal");

    	//increase velocity while jump button is pressed
    	if (Input.GetButtonDown("Jump") && grounded) {
    		velocity.y = jumpTakeOffSpeed;
    	//reduce upward velocity if button is released
    	} else if (Input.GetButtonUp("Jump")) {
    		if (velocity.y > 0) {
    			velocity.y = velocity.y * .5f;
    		}
    	}

    	targetVelocity =  move * maxSpeed;

    }
}
