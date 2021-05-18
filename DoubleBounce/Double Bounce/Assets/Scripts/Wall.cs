using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle") {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            rb.velocity = -rb.velocity;
        }
    }
}
