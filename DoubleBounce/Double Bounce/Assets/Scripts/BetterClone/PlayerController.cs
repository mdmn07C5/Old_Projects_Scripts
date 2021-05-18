using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BetterClone
{
    public class PlayerController : MonoBehaviour
    {
        public float sensitivity = 50f;
        float roll;

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButton(0))
            {
                HandleRotation();
            }
        }

        void HandleRotation()
        {
            roll = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;

            transform.Rotate(Vector3.forward, roll, Space.World);
        }
    }
}