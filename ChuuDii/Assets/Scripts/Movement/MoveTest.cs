using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTest : MonoBehaviour
{
	public float gravity = -0.01f;
	public Vector2 velocity;
	public CollisionDetector collider;
    // Start is called before the first frame update
    void Start()
    {
    	collider = GetComponent<CollisionDetector>();
    }

    // Update is called once per frame
    void Update()
    {
    	velocity.x = Input.GetAxisRaw("Horizontal");
    	velocity.y += gravity * Time.deltaTime;

    	if (velocity.x != 0)
    	{
    		collider.HorizontalCollisions(ref velocity);
    	}
    	if (velocity.y !=0){
    		collider.VerticalCollisions(ref velocity);
    	}


    	transform.Translate(velocity);    
    }

    void FixedUdate()
    {
    }
}
