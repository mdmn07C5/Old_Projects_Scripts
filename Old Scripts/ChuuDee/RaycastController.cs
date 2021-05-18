﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class RaycastController : MonoBehaviour
{

	public LayerMask collisionMask;

	//we'd like to pretend we only have 16 bits to play with
	public int bitCount = 16; 

	public const float skinWidth = 0.015f;
	public int horizontalRayCount = 5;
	public int verticalRayCount = 5;

	[HideInInspector]
	public float horizontalRaySpacing;
	[HideInInspector]
	public float verticalRaySpacing;
	[HideInInspector]
	public BoxCollider2D collider;
	[HideInInspector]
	public RaycastOrigins raycastOrigins;

	
    public virtual void Start() {
        collider = GetComponent<BoxCollider2D>();
    	CalculateRaySpacing();
    }


	public void UpdateRaycastOrigins() 
    {
    	Bounds bounds = collider.bounds;
    	bounds.Expand(skinWidth * -2);

    	raycastOrigins.bottomLeft = new Vector2(bounds.min.x, bounds.min.y);
    	raycastOrigins.bottomRight = new Vector2(bounds.max.x, bounds.min.y);
    	raycastOrigins.topLeft = new Vector2(bounds.min.x, bounds.max.y);
    	raycastOrigins.topRight = new Vector2(bounds.max.x, bounds.max.y);

    }

    public void CalculateRaySpacing() 
    {
    	Bounds bounds = collider.bounds;
    	bounds.Expand(skinWidth * -2);

    	horizontalRayCount = Mathf.Clamp(horizontalRayCount, 2, int.MaxValue);
    	verticalRayCount = Mathf.Clamp(verticalRayCount, 2, int.MaxValue);

    	horizontalRaySpacing = bounds.size.y / (horizontalRayCount - 1);
    	verticalRaySpacing = bounds.size.x / (verticalRayCount - 1);
    }

    public struct RaycastOrigins 
    {
    	public Vector2 topLeft, topRight;
    	public Vector2 bottomLeft, bottomRight;
    }

}
