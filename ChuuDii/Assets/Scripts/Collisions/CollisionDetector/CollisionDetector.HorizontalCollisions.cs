using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class CollisionDetector : RaycastController
{
    public void HorizontalCollisions(ref Vector2 velocity)
    {
    	float directionX = Mathf.Sign(velocity.x);
    	float rayLength = Mathf.Abs(velocity.x) + skinWidth;

        for (int i = 0; i < horizontalRayCount; ++i) {
        	Vector2 rayOrigin = SetRayOrigin(true, directionX);

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
}
