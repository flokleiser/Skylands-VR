using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TennisBall : MonoBehaviour
{
    public AudioClip ballimpact;
    AudioSource audioSource;
    private Rigidbody rb;
    float ballmagnitude;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        ballmagnitude = rb.velocity.magnitude / 2;
        float volumeball = rb.velocity.magnitude;
        if (volumeball > 20) volumeball = 20;
        audioSource.PlayOneShot(audioSource.clip, volumeball / 20);
        if (ballmagnitude > 1)
        {
            ballmagnitude = 1;
        }
        audioSource.PlayOneShot(ballimpact, ballmagnitude);
    }
}