using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BetterClone {

    [RequireComponent(typeof(Rigidbody))]
    public class EnemyMovement : MonoBehaviour
    {
        // Start is called before the first frame update

        public float EnemyMovementSpeed;
        private Rigidbody rb;

        void Awake()
        {
            rb = GetComponent<Rigidbody>();
            // transform.forward = transform.parent.right;  
        }
        void Start()
        {
            rb.velocity = transform.right * EnemyMovementSpeed;
        }

        // Update is called once per frame
        void OnCollisionEnter(Collision other)
        {
            if ( other.gameObject.tag is "Ring" )
            {
                Destroy(this.gameObject);
            }
        }

    }
}

