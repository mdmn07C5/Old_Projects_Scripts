using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : RaycastController
{
    // Start is called before the first frame update

	// public CollisionInfo collisions;
    public Player player;
    // public BoxCollider2D collider;
    public LayerMask layerMask;
    
    RaycastHit2D[] hitBuffer;
    List<RaycastHit2D> hitBufferList = new List<RaycastHit2D>(16);

    public override void Start()
    {
        base.Start();
    	player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
    	    
    }

    void FixedUpdate()
    {
    	CheckRange();
    	Hit();
    }

    public void CheckRange()
    {
    	UpdateRaycastOrigins();
    	for (int i = 0; i < horizontalRayCount; ++i) {
    		Vector2 rayOrigin;
    		if (player.playerDirection == 1) 
    		{
    			rayOrigin = raycastOrigins.bottomRight;
    		}
    		else 
    		{
    			rayOrigin = raycastOrigins.bottomLeft;
    		}
    		Debug.DrawRay(rayOrigin + Vector2.up * horizontalRaySpacing * i, 
    					  Vector2.right * player.playerDirection * collider.bounds.size,
    					  Color.blue);

    		hitBuffer = Physics2D.RaycastAll(rayOrigin,
											 Vector2.right * player.playerDirection,
											 collider.bounds.size.x, layerMask);
    	
    	}
    }

    public void Hit()
    {
        if (Input.GetKeyDown(KeyCode.F)){
        	foreach (RaycastHit2D thing in hitBuffer) {
        		// print(thing.transform.position);
        		// Destroy(thing.collider.gameObject);
                // Health thingHP = thing.collider.gameObject.GetComponent<Health>();
                // thingHP.AddHitPoints(-50);
                GameObject thingGO = thing.collider.gameObject;
                thingGO.GetComponent<Health>().AddHitPoints(-50);
                // thingHP.AddHitPoints(-50);
            }
        }
    }

}
