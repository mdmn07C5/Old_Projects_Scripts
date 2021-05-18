using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public partial class RaycastController : MonoBehaviour
{   

	public LayerMask collisionMask;

	public readonly float skinWidth = 0.015f;
	public int horizontalRayCount = 5;
	public int verticalRayCount = 5;

	[HideInInspector]
	public float horizontalRaySpacing;
	[HideInInspector]
	public float verticalRaySpacing;
	[HideInInspector]
	public BoxCollider2D boxCollider2D;
	[HideInInspector]
	public RaycastOrigins raycastOrigins;

	
    public virtual void Start() 
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    void Update()
    {

    }

    public struct RaycastOrigins
    {
    	public Vector2 topLeft, topRight;
    	public Vector2 bottomLeft, bottomRight;
    }

}
