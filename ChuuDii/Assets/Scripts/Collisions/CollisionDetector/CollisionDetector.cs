using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class CollisionDetector : RaycastController
{

	public CollisionInfo collisions;


	public override void Start()
	{
		base.Start();
		CalculateRaySpacing();
	}

	void Update()
	{
		// UpdateRaycastOrigins();
		// DebugDrawRays();
	}

	void FixedUpdate()
	{

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
