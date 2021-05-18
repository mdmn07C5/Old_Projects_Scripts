using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerDefaultPhysics : MonoBehaviour
{

	private bool grounded;
	private Vector2 groundNormal;
	private ContactFilter2D contactFilter;
	private RaycastHit2D[] hitBuffer = new RaycastHit2D[16];
	private List<RaycastHit2D> hitBufferList = new List<RaycastHit2D> (16);
	private Rigidbody2D rb2d;

	public float moveSpeed = 7;
	[Range(0,1)] public float slideFactor = 0.9f;
	public float jumpForce = 5;


	void OnEnable()
	{
		rb2d = GetComponent<Rigidbody2D>();
	}

	void Start()
	{
		contactFilter.SetLayerMask 
			(Physics2D.GetLayerCollisionMask(gameObject.layer));
	}

    void FixedUpdate()
    {
    	float h = Input.GetAxisRaw("Horizontal");
    	Vector2 v = rb2d.velocity;

    	grounded = false;

    	float distance  = v.magnitude;

    	// int count = rb2d.Cast(v, contactFilter, )

    	if (h !=0) {
    		rb2d.velocity = new Vector2(h * moveSpeed, v.y);
    	}
    	else {
    		rb2d.velocity = new Vector2(h * slideFactor, v.y);
    	}

    	if(Input.GetButtonDown("Jump"))
    	{
    		rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    	}
    }




}
