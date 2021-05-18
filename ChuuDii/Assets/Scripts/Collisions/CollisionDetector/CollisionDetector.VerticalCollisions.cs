using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class CollisionDetector : RaycastController
{
    public void VerticalCollisions(ref Vector2 velocity)
    {
    	float directionY = Mathf.Sign (velocity.y);
    	float rayLength = Mathf.Abs (velocity.y) + skinWidth;

        for (int i = 0; i < verticalRayCount; ++i) 
        {
        	Vector2 rayOrigin = SetRayOrigin(false, directionY);

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
}
