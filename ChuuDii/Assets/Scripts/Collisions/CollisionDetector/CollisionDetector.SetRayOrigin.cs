using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class CollisionDetector : RaycastController
{
    public Vector2 SetRayOrigin(bool isHorizontal, float direction)
    {
        if (isHorizontal) 
        {
            if (direction == -1)
            {
                return raycastOrigins.bottomLeft;
            }
            else
            {
                return raycastOrigins.bottomRight;
            }
        }
        else
        {
            if (direction == -1)
            {
                return raycastOrigins.bottomLeft;
            }
            else
            {
                return raycastOrigins.topLeft;
            }
        }
    }
}
