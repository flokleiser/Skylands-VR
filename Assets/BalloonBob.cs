using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonBob : MonoBehaviour
{
    private Vector3 initialPosition;
    public float amp;
    public float delay = 5f;

    private void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {

        float x = transform.position.x;
        float y = transform.position.y;
        float z = transform.position.z;

        transform.position = new Vector3(transform.position.x, Mathf.Sin(Time.time) * amp, transform.position.z);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("check");

            Invoke("MoveBalloon", delay);
        }
    }

    private void MoveBalloon()
    {
        transform.position = new Vector3(30, 30, 30);
    }
}