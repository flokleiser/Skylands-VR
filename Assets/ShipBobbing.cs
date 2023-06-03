using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBobbing : MonoBehaviour
{
    private Vector3 initialPosition;
    public float amp;

    private void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {

        float x = initialPosition.x;
        float y = initialPosition.y;
        float z = initialPosition.z;

        transform.position = new Vector3(initialPosition.x, Mathf.Sin(Time.time) * amp, initialPosition.z);

    }
}
