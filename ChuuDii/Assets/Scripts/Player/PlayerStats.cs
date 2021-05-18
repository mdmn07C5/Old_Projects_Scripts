using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName="Custom Assets/New Player Stats")]
public class PlayerStats : ScriptableObject
{
    public float moveSpeed = 2;
    public float jumpHeight = 1;
    public float timeToJumpApex = .5f;

    public float accelerationTimeAirborne = .4f;
    public float accelerationTimeGrounded = .1f;
}
