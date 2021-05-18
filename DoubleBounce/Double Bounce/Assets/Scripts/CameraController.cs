using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float duration;
    public Vector2 magnitude;

    Vector3 shakeOffset;
    Vector3 playerOffset;
    Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShakeCamera();
        }
    }

    public void ShakeCamera()
    {
        IEnumerator co = CoroutineShake(this.duration, this.magnitude);
        StartCoroutine(co);
    }

    public void ShakeCamera(float duration, Vector2 magnitude) {
        IEnumerator co = CoroutineShake(duration, magnitude);
        StartCoroutine(co);
    }

    IEnumerator CoroutineShake(float duration, Vector2 magnitude)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude.x;
            float y = Random.Range(-1f, 1f) * magnitude.y;

            shakeOffset = new Vector3(x, y, 0);
            elapsed += Time.deltaTime;
            yield return 0;
        }
        shakeOffset = Vector3.zero;
    }

    void OnPlayerLand() {
        
    }

    private void FixedUpdate()
    {
        transform.position = initialPosition + shakeOffset + playerOffset;
    }

}
