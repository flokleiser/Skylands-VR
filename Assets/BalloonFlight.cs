using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonFlight : MonoBehaviour
{

    public float radius = 10f;
    public float speed = 1f;
    public float currentAngle = 0f;
    public float amp = 1f;
    public float floatSpeed = 1f;

    private Vector3 initialPosition;    // Initial position of the GameObject


    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Increment the angle based on the speed and time
        currentAngle += speed * Time.deltaTime;

        // Calculate the new position based on the angle and radius
        float x = initialPosition.x + Mathf.Cos(currentAngle) * radius;
        float y = initialPosition.y + Mathf.Sin(Time.time) * amp;
        float z = initialPosition.z + Mathf.Sin(currentAngle) * radius;

        // Set the new position
        transform.position = new Vector3(x, y, z);
    }
}