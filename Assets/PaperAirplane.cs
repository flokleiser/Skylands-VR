using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperAirplane : MonoBehaviour
{
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // Apply additional forces or adjustments to the Rigidbody as needed
        // to mimic the behavior of a paper airplane.
    }
}