using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{

	public GameMaster gm;

    // Start is called before the first frame update
    void Start()
    {
        // gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
    	Debug.Log("Collision with " + other.name);
    	if (other.gameObject.tag == "Player")
    		gm.KillPlayer();
	}

	void OnTriggerStay2D(Collider2D other)
	{
		Debug.Log("OnStay");
	}
}
