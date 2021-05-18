using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller2D : RaycastController
{

	public CollisionInfo collisions;
    // Start is called before the first frame update

    public override void Start()
    {
        base.Start();
    }

    protected void HorizontalCollisions(ref Vector2 velocity) {
    	float directionX = Mathf.Sign(velocity.x);
    	float rayLength = Mathf.Abs(velocity.x) + skinWidth;

        for (int i = 0; i < horizontalRayCount; ++i) {
        	Vector2 rayOrigin;
        	if (directionX == -1)
        	{
        		rayOrigin = raycastOrigins.bottomLeft;
        	}
        	else
        	{
        		rayOrigin = raycastOrigins.bottomRight;
        	}


            rayOrigin += Vector2.up * (horizontalRaySpacing * i);
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, 
                                                Vector2.right * directionX, 
                                                rayLength, collisionMask);

            // Debug.DrawRay(rayOrigin - Vector2.right * directionX * horizontalRaySpacing, Vector2.right * directionX, Color.blue);

 			Debug.DrawRay(rayOrigin, Vector2.right * directionX * rayLength,
 							Color.red);       	

        	if (hit) {
        		velocity.x = (hit.distance - skinWidth) * directionX;
        		rayLength = hit.distance;

        		collisions.left = directionX == -1;
        		collisions.right = directionX == 1;
        	}
        }

    }

    protected void VerticalCollisions(ref Vector2 velocity) 
    {
    	float directionY = Mathf.Sign (velocity.y);
    	float rayLength = Mathf.Abs (velocity.y) + skinWidth;

        for (int i = 0; i < verticalRayCount; ++i) 
        {
        	Vector2 rayOrigin;
        	if (directionY == -1)
        	{
        		rayOrigin = raycastOrigins.bottomLeft;
        	}
        	else
        	{
        		rayOrigin = raycastOrigins.topLeft;
        	}

        	rayOrigin += Vector2.right * (verticalRaySpacing * i + velocity.x);
        	RaycastHit2D hit = Physics2D.Raycast(rayOrigin, 
        										Vector2.up * directionY, 
        										rayLength, collisionMask);

   			Debug.DrawRay(rayOrigin, Vector2.up * directionY * rayLength,
   							Color.red);
     
        	if (hit) {
        		velocity.y = (hit.distance - skinWidth) * directionY ;
        		rayLength = hit.distance;

        		collisions.below = directionY == -1;
        		collisions.above = directionY == 1;
        	}
        }
    }


    
    public struct CollisionInfo 
    {
    	public bool above, below;
    	public bool left, right;

    	public void Reset()
    	{
    		above = below = false;
    		left = right = false;
    	}
    }

}
