using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	private Rigidbody2D rb2d;
	private ContactFilter2D contactFilter;

	public float maxVelocity = 5f;
	public float gravityModifier = 1f;
	public float jumpHeight = 7f;

	void OnEnable()
	{
		rb2d = GetComponent<Rigidbody2D>();
	}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
    	//Constant pull of gravity
    	// velocity += gravityModifier * Physics2D.gravity * Time.deltaTime;

    	Move();
    }

    void Move()
    {
        Debug.Log(rb2d.velocity);
    	float h = Input.GetAxisRaw("Horizontal");
    	Vector2 v = rb2d.velocity;

        if (h != 0)
			rb2d.velocity = new Vector2(h * maxVelocity, v.y);
		else
			rb2d.velocity = new Vector2(h * 0.5f, v.y);


		//Jumping
		if(Input.GetButtonDown("Jump") &&  isGrounded())
		{
			rb2d.velocity = new Vector2(v.x, jumpHeight);
			// rb2d.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
		// reduce upward velocity if button is released
		} else if (Input.GetButtonUp("Jump")) {
			if (rb2d.velocity.y > 0) {
				rb2d.velocity = new Vector2(v.x, v.y * .5f);
			}
		}

    }

    bool isGrounded()
    {
    	int ground = LayerMask.NameToLayer("Ground");
    	// Debug.Log(LayerMask.NameToLayer("Ground"));
    	// Debug.Log(rb2d.IsTouchingLayers(ground));
    	return rb2d.IsTouchingLayers();
    }
}
