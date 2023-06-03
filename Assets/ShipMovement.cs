using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public GameObject Ship;

    private Vector3 initialPosition;

    public float radius = 40f;
    public float speed = 1f;
    public float currentAngle = 0f;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        currentAngle += speed * Time.deltaTime;
        float x = initialPosition.x + Mathf.Cos(currentAngle) * radius;
        float y = initialPosition.y;
        float z = initialPosition.z + Mathf.Sin(currentAngle) * radius;

        transform.position = new Vector3(x, y, z);

        Vector3 lookDirection = new Vector3(-Mathf.Sin(currentAngle), 0f, Mathf.Cos(currentAngle));
        Quaternion lookRotation = Quaternion.LookRotation(lookDirection, Vector3.up);

        transform.rotation = lookRotation;

    }
}
