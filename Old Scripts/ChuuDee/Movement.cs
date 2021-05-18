using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : Controller2D
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public void Move(Vector2 velocity) {
        UpdateRaycastOrigins();
        collisions.Reset();

        if (velocity.x != 0)
        {
        	HorizontalCollisions(ref velocity);
        }
    	if (velocity.y != 0)
    	{
        	VerticalCollisions(ref velocity);
    	}

    	transform.Translate(velocity);
    }

}
