using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BetterClone {
    public class EnemySpawner : MonoBehaviour
    {
        public GameObject enemyPrefab;
        public Vector2 spawnTime;
        public float spawnDelay;
        private float timer = 0;
        
        // Start is called before the first frame update
        void Start()
        {
            spawnDelay = Random.Range(spawnTime.x, spawnTime.y);
            // transform.rotation = Quaternion.Euler(0, 0, Random.Range(-180f, 180f));
        }

        // Update is called once per frame
        void Update()
        {
            if ( timer > spawnDelay )
            {
                SpawnEnemy();
                timer = 0;
                spawnDelay = Random.Range(spawnTime.x, spawnTime.y);
                transform.rotation = Quaternion.Euler(0, 0, Random.Range(-180f, 180f));
            }
            timer += Time.deltaTime;
        }

        void SpawnEnemy()
        {
            // Debug.Log(q);
            // GameObject enemyClone = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            // enemyClone.transform.forward = transform.forward;
            Instantiate(enemyPrefab, transform.position, Quaternion.Euler(0, 0, Random.Range(-180f, 180f)));
        }
    }
}


