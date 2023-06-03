using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonPath : MonoBehaviour
{
    public float delay = 3f;


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
        transform.position = new Vector3(10, 10, 10);
    }
}