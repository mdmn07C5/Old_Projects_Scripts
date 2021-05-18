using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PlayerPhysics))]
public class PlayerController1 : MonoBehaviour
{
	public float 	m_speed = 2.0f;
	public float 	m_acceleration = 1.0f;
	public float 	m_jumpHeight = 10.0f;

	private float 	m_currentSpeed;
	private float 	m_maxSpeed = 6.0f;
	private Vector2 moveAmount;		

	private PlayerPhysics playerPhysics;

    // Start is called before the first frame update
    void Start()
    {
        playerPhysics = GetComponent<PlayerPhysics>();

    }

    // Update is called once per frame
    void Update()
    {
    	m_maxSpeed = Input.GetAxisRaw("Horizontal") * m_speed;
    	m_currentSpeed = IncrementTowards(m_currentSpeed, m_maxSpeed, m_acceleration);
    	
    	if (Input.GetButtonDown("Jump")) {
    		if (playerPhysics.isGrounded()){
    			moveAmount.y = m_jumpHeight;
    		}
    	}

    	moveAmount.x = m_currentSpeed;
    	playerPhysics.Move(moveAmount * Time.deltaTime);
    	moveAmount.y = 0;
    }

    private float IncrementTowards(float n, float target, float acceleration)
    {
    	if (n == target) {
    		return n;
    	}
    	else {
    		float direction = Mathf.Sign(target - n);
    		n += acceleration * Time.deltaTime * direction;
    		return (direction == Mathf.Sign(target - n))? n : target;
    	}
    }
}
