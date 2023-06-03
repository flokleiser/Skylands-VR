using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonPathNew : MonoBehaviour
{
    public Transform targetPosition;
    public float movementDuration = 15f;
    public float delay = 3f;

    private bool isMoving = false;
    private Vector3 initialPosition;
    private float movementStartTime;
    

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        if (isMoving)
        {
            float timeSinceStarted = Time.time - movementStartTime;
            float percentageComplete = timeSinceStarted / movementDuration;

            float smoothedPercentage = Mathf.SmoothStep(0f, 1f, percentageComplete);

            transform.position = Vector3.Lerp(initialPosition, targetPosition.position, smoothedPercentage);

            if (percentageComplete >= 1.0f)
            {
                isMoving = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("check");

            StartMovement(targetPosition.position);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        StartMovement(initialPosition);
    }

    private void StartMovement(Vector3 destination)
    {
        initialPosition = transform.position;
        targetPosition.position = destination;
        movementStartTime = Time.time + delay;
        isMoving = true;
    }
}
