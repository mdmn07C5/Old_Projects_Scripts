using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameMaster : MonoBehaviour
{

	public static GameMaster gm;
	public Transform playerPrefab;
	public Transform spawnPoint;
	public int spawnDelay = 1;

    void Start()
    {
     	if (gm == null)
     	{
     		gm = this;
     	}
    }

    public void UpdateSpawnPoint()
    {
    	//for now
    	// spawnPoint = new
    }

    public IEnumerator RespawnPlayer(GameObject player)
    {
    	yield return new WaitForSeconds(spawnDelay);
        player.SetActive(true);
        player.transform.position = spawnPoint.position;

    	
    	// Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    public static void KillPlayer(GameObject player)
    {
        // Destroy(player);
        player.SetActive(false);
    	gm.StartCoroutine(gm.RespawnPlayer(player));
    	// player = Instantiate(player, new Vector2(0, 5.3f), Quaternion.identity);
    }
}