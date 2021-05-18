using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{

    private float skinWidth = 0.015f;
    public float jumpHeight = 4;
    public float timeToJumpApex = .4f;
    public float fallMultiplier = 1f;
    float gravity;
    float jumpVelocity;

    bool isGrounded;

    Rigidbody rb;

    private static PlayerController instance = null;

    public static PlayerController Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        instance = this;
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void Start()
    {
        isGrounded = true;
        gravity = -(2 * jumpHeight) / Mathf.Pow (timeToJumpApex, 2);
    }

    void Update()
    {
        gravity = -(2 * jumpHeight) / Mathf.Pow (timeToJumpApex, 2);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump(jumpHeight, timeToJumpApex);
        }

    }

    void Jump(float jumpHeight, float timeToJumpApex) {
        jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        rb.velocity = Vector3.up * jumpVelocity;
    }


    private void FixedUpdate()
    {
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y + ( fallMultiplier * gravity * Time.deltaTime), rb.velocity.z);
    }

}