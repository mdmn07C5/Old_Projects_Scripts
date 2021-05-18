using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{

	public static GameMaster gm;
	public static GameObject player;
	public Transform playerPrefab;
	public Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        if (gm == null) 
        	gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    
    	player = GameObject.FindGameObjectWithTag("Player").GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void KillPlayer()
    {
    	Debug.Log("Player killed");
    	Destroy(player.gameObject);
    	gm.RespawnPlayer();
    }

    public void RespawnPlayer()
    {
    	Debug.Log("Respawning Player at" + spawnPoint.position.ToString());
    	Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
    }

}
