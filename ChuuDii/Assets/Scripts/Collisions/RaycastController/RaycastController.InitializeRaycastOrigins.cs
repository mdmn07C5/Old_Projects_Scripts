using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class RaycastController : MonoBehaviour
{
    // Start is called before the first frame update
	public void InitializeRaycastOrigins()
	{
		Bounds bounds = boxCollider2D.bounds;
    	bounds.Expand(skinWidth * -2);

    	raycastOrigins.bottomLeft = new Vector2(bounds.min.x, bounds.min.y);
    	raycastOrigins.bottomRight = new Vector2(bounds.max.x, bounds.min.y);
    	raycastOrigins.topLeft = new Vector2(bounds.min.x, bounds.max.y);
    	raycastOrigins.topRight = new Vector2(bounds.max.x, bounds.max.y);
	}
}
