using UnityEngine;

public class JumpEvent : MonoBehaviour
{
	public PlayerStats playerStats;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
    	PlayerInputHandler.OnJump += Jump; 
    }

    void OnDisable()
    {
    	PlayerInputHandler.OnJump -= Jump;
    }

    void Jump(GameObject go)
    {	
    	print("event called");
    	PlayerMovementController pmc = go.GetComponentInChildren<PlayerMovementController>();
    	CollisionDetector col = go.GetComponentInChildren<CollisionDetector>();


    	// if grounded
    	if (col.collisions.below)
    	{
    		// col.UpdateRaycastOrigins();
    		// col.collisions.Reset();
    		if (pmc.velocity.y < playerStats.jumpHeight) {
    			print("jump");
    			pmc.velocity.y = playerStats.jumpHeight;
    		}
    	}
    }
}
