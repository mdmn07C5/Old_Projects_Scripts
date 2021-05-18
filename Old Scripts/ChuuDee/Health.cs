using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
	[SerializeField]
	int hitPoints = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddHitPoints(int amount)
    {
    	hitPoints += amount;
    	print("subtracted " + amount + " hit points");
    	if(hitPoints <= 0)
    	{
    		print("I am a dead boi");
    		Destroy(this.gameObject);
    	}
    }
}
