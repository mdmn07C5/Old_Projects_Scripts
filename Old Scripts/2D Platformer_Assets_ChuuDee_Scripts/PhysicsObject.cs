using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObject : MonoBehaviour
{
	//this will allow us to scale the gravity by a float
    public float gravityModifier = 1f;

    //threshold for what angle is considered 'flat'/normal
    public float minGroundNormalY = 0.65f;

    //protected because other classes are going to inherit from this
    //this class and we want them to be able to access these variables
    //but we don't want it to be accessible outside the class
    
    //targetVelocity is where we will store incoming input from outside the class
    //as to where the object is trying to move
    protected Vector2 targetVelocity;
    protected bool grounded;
    protected Vector2 groundNormal;
    protected Vector2 velocity;
    protected Rigidbody2D rb2d;
    protected ContactFilter2D contactFilter;
    protected const float minMoveDistance = 0.001f;

    //Raycast hit 2d objects, 16 is arbitrary.
    protected RaycastHit2D[] hitBuffer = new RaycastHit2D[16];

    //List of objects that overlap PhysicsObject2D.
    protected List<RaycastHit2D> hitBufferList = new List<RaycastHit2D> (16);

    //Shell to make sure we object does not get stuck in another collider
   	protected const float shellRadius = 0.01f; 

    void OnEnable()
    {
    	rb2d = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
    	//We're not checking collision against triggers
		// contactFilter.useTriggers = false;        

		//Get layer mask from current project settings for Physics2D
		contactFilter.SetLayerMask 
			(Physics2D.GetLayerCollisionMask(gameObject.layer));

		contactFilter.useLayerMask = true;
    }

    // Update is called once per frame
    void Update()
    {
        //reset the velocity each time so we don't get any 'left over' constant movement
        targetVelocity = Vector2.zero;
        ComputeVelocity();
    }

    protected virtual void ComputeVelocity()
    {

    }

    void FixedUpdate()
    {

        //Our object is constantly 'moving' downward due to gravity
    	velocity += gravityModifier * Physics2D.gravity * Time.deltaTime;
    	velocity.x = targetVelocity.x;

    	//set grounded to false after each move
    	grounded = false;

    	//change in position due to gravity
    	Vector2 deltaPosition = velocity * Time.deltaTime;

    	//the direction we are trying to move along the ground if ground is a slope
    	Vector2 moveAlongGround = new Vector2(groundNormal.y, groundNormal.x);

    	//horizontal movement
    	Vector2 move = moveAlongGround * deltaPosition.x;

    	Movement(move, false);

    	//vertical movement
    	move = Vector2.up * deltaPosition.y;
    
    	Movement(move, true);
    }

    void Movement(Vector2 move, bool yMovement)
    {
    	
    	//We're going to use the magnitudeof move vector to determine the 
    	//distance we're going to move. 
    	float distance = move.magnitude;

    	//We only want to apply collision if the distance we're attempting
    	//to move is greater than a minimum value (minMoveDistance).
    	//This is going to prevent our objects from constantly checking for
    	//collision when they're stationary.
    	if (distance > minMoveDistance) {
    		//Check if any of the attached colliders of our rb2d are going
    		//to overlap with anything in the next frame.

    		//shellRadius makes sure object's collider does not go past 
    		//other collider and get stuck.
    		int count = rb2d.Cast(move, contactFilter, hitBuffer, 
    							distance + shellRadius);
    		hitBufferList.Clear();
    		//copying over only entries that have something in them
    		for (int i = 0; i < count; ++i) {
    			hitBufferList.Add(hitBuffer[i]);
    		}

    		for (int i = 0; i < hitBufferList.Count; ++i) {
    			//toggle groundedness if any of the overlaping colliders
    			//are greater than our threshold for a 'flat' surface
    			Vector2 currentNormal = hitBufferList[i].normal;
                // Debug.Log(currentNormal);
    			if (currentNormal.y > minGroundNormalY) {
    				grounded = true;
    				if (yMovement) {
    					groundNormal = currentNormal;
    					currentNormal.x = 0;
    				}

    				//Get the difference between velocity and currentNormal
    				//to determine wether we need to subtract from velocity
    				//to prevent object from entering another collider
    				float projection = Vector2.Dot(velocity, currentNormal);
    				if (projection < 0) {
    					velocity = velocity - projection * currentNormal;
    				}

    				//check if collision in lists distance is less than
    				//shell size constant to prevent getting stuck in 
    				//other colliders

    				float modifiedDistance = hitBufferList[i].distance - shellRadius;

					distance = modifiedDistance < distance ? modifiedDistance : distance; 
    			}
    		}
    	}

    	//movement will be done by altering the position of the rb2d
    	rb2d.position = rb2d.position + move.normalized * distance;

    }

    //Our colliders will pass through the floor since its being moved
	//by a script. we are going to need to manually check for collision
	//then update the move of the object.
	// 
}

