using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PlayerPhysics))]
public class PlayerController : MonoBehaviour
{

    [SerializeField] private float m_JumpForce = 200f;

    private bool m_Grounded;
    private Rigidbody2D m_RB2D;
    private bool m_FacingRight = true;


    // Start is called before the first frame update
    void Start()
    {
        m_RB2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Move(float move, bool jump)
    {

    }
}