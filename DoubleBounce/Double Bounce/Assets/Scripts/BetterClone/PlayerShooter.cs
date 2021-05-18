using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BetterClone
{
    public class PlayerShooter : MonoBehaviour
    {
        public GameObject bulletPrefab;
        public Transform spawnPos;
        public float force;
        public float delay;
        float stamp;

        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                if (Time.time >= stamp)
                {
                    stamp = Time.time + delay;
                    GameObject bullet = Instantiate(bulletPrefab, spawnPos.position, Quaternion.identity);

                    Vector3 dir = transform.position - bullet.transform.position;
                    bullet.GetComponent<Rigidbody>().AddForce(force * dir.normalized);
                }
            }
        }
    }
}
