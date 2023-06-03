using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballrespawn : MonoBehaviour
{
    public GameObject ball;
    [SerializeField] Transform respawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Respawn Plane"))
        {
            Debug.Log("check");

            ball.transform.position = respawnPoint.transform.position;
        }
    }
}
