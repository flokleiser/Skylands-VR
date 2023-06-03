using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class respawn : MonoBehaviour
{
    [SerializeField] Transform respawnPoint;
    public GameObject player;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("check");

            player.transform.position = respawnPoint.transform.position;
        }
    }

    //void OnCollisionEnter(Collision other)
    //{
    //    if(other.gameObject.CompareTag("Player"))
    //    {
    //        Debug.Log("check");

    //        player.transform.position = respawnPoint.transform.position;
    //    }
    //}

}
