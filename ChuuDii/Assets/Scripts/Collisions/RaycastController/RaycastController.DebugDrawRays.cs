using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class RaycastController : MonoBehaviour
{
	public void DebugDrawRays()
	{
		InitializeRaycastOrigins();
		CalculateRaySpacing();
		for (int i = 0; i < verticalRayCount; ++i) {
			Debug.DrawRay(raycastOrigins.bottomLeft + 
						  Vector2.right * verticalRaySpacing * i,
						  Vector2.up * -2,
						  Color.red);
		}
	}

}
