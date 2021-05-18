using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Obstacle : MonoBehaviour
{
    public float speed;

    Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        rb.velocity = Vector3.left * speed;
    }

    private void FixedUpdate()
    {
        rb.velocity = rb.velocity.normalized * speed* Time.fixedDeltaTime;
    }



}
