using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerControl : MonoBehaviour
{
	public float WalkSpeed, JumpHeight;
	public AnimationClip walk;
	public bool facingRight;
	public Transform GroundCast;
	public float fallMultiplier;
	public float riseMultiplier;

	private bool canJump, isJump;
	private float rot, startScale;
	private Rigidbody2D rig;
	private RaycastHit2D hit2D;


    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        startScale = transform.localScale.x;
        facingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        if ( hit2D = Physics2D.Linecast(new Vector2(GroundCast.position.x, GroundCast.position.y), GroundCast.position) )
        {
        	if ( !hit2D.transform.CompareTag("Player") )
        	{
        		canJump = true;
        	}
        } else {
        	canJump = false;
        }
        Debug.Log("Can Jump:" + canJump);

        // Debug.Log(Input.GetAxisRaw("Vertical"));
        if ( Input.GetAxisRaw("Vertical") > 0 && canJump )
        {
        	isJump = true;
        	Debug.Log("Is Jump: " + isJump);
        }
    }

    void FixedUpdate()
    {
    	if ( Input.GetAxisRaw("Horizontal") < 0 )
    	{
    		facingRight = false;
    	} else if ( Input.GetAxisRaw("Horizontal") > 0 ) {
    		facingRight = true;
    	}

    	if ( facingRight ) 
    	{
    		// rot = Mathf.Atan2(transform.rotation.y, transform.rotation.x) * Mathf.Rad2Deg;
    		transform.position += Vector3.right * WalkSpeed * Time.deltaTime;
    		transform.localScale = new Vector3(startScale, startScale, 1);
    	} else {
    		transform.position += -Vector3.right * WalkSpeed * Time.deltaTime;
    		transform.localScale = new Vector3(-startScale, startScale, 1);
    		// transform.posiiton -= Vector3
    		// rot = Mathf.Atan2(-transform.rotation.y, -transform.rotation.x) * Mathf.Rad2Deg;
    	}

    	if ( isJump )
    	{
    		rig.velocity = Vector3.up * JumpHeight;
    		// rig.AddForce(transform.up * JumpHeight * Time.deltaTime);
    		canJump = false;
    		isJump = false;
    	}

    	if ( rig.velocity.y < 0 ) 
    	{
    		rig.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
    	} else if ( rig.velocity.y > 0 ) {
    		rig.velocity += Vector2.up * JumpHeight * riseMultiplier * Time.deltaTime;
    	}

    }
}
