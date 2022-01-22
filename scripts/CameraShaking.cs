using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaking : MonoBehaviour
{
    [SerializeField] private float power = 0.05f;
    [SerializeField] private float duration = 1f;
    private float slowDownAmount = 1f;
    private bool shouldShake = false;
    [SerializeField] public Transform camera;
    Vector3 startPosition;
    float initialDuration;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main.transform;
        startPosition = camera.localPosition;
        initialDuration = duration;
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldShake)
        {
            if (duration > 0)
            {
                camera.localPosition = startPosition + Random.insideUnitSphere * power;
                duration -= Time.deltaTime * slowDownAmount;
            }
            else
            {
                shouldShake = false;
                duration = initialDuration;
                camera.localPosition = startPosition;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            shouldShake = true;
        }
        if (other.tag == "Enemy")
        {
            shouldShake = true;
        }
    }
}