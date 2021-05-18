using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysics : MonoBehaviour
{
    private Collider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider2D>();        
    }

    // Update is called once per frame
    void Update()
    {

    }



    public void Move(Vector2 moveAmount)
    {
    	transform.Translate(moveAmount);
    }

    public bool isGrounded()
    {
        return collider.IsTouchingLayers(LayerMask.GetMask("Ground"));
    }
}
