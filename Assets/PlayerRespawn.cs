using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public GameObject player;
    [SerializeField] Transform respawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Respawn Plane"))
        {
            Debug.Log("check");

            player.transform.position = respawnPoint.transform.position;

            //chatgpt script, delete if not works
            Rigidbody playerRigidbody = player.GetComponent<Rigidbody>();
            if (playerRigidbody != null)
            {
                playerRigidbody.velocity = Vector3.zero;

            }
        }
    }


}
