using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class RaycastController : MonoBehaviour
{
	//Calculate even spacing between Raycasts.
	//RayCounts are clamped between two - for each corner of each side,
	//and whatever the designer sets it to - in this case the maximum int value
    //the bounds are shrunk inward by a factor of [skinWidth] to remove the
    //space between the colliders when collissions are applied using this
    //controller
    public void CalculateRaySpacing() 
    {
    	Bounds bounds = boxCollider2D.bounds;
    	bounds.Expand(skinWidth * -2);

    	horizontalRayCount = Mathf.Clamp(horizontalRayCount, 2, int.MaxValue);
    	verticalRayCount = Mathf.Clamp(verticalRayCount, 2, int.MaxValue);

    	horizontalRaySpacing = bounds.size.y / (horizontalRayCount - 1);
    	verticalRaySpacing = bounds.size.x / (verticalRayCount - 1);
    }
}
