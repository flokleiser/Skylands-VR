using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class BalloonSteer : MonoBehaviour
{
    public XRController controller;
    public CharacterController characterController;
    public Transform ejectionPoint;
    public float ejectionForce = 5f;

    private bool playerInsideTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInsideTrigger = true;

            // Disable the Character Controller
            characterController.enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInsideTrigger = false;

            // Enable the Character Controller
            characterController.enabled = true;
        }
    }

    private void Update()
    {
        if (playerInsideTrigger && controller.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue) && primaryButtonValue)
        {
            // Eject the player
            EjectPlayer();
        }
    }

    private void EjectPlayer()
    {
        // Enable the Character Controller
        characterController.enabled = true;

        // Calculate ejection direction
        Vector3 ejectionDirection = (ejectionPoint.position - controller.transform.position).normalized;

        // Apply ejection force
        characterController.Move(ejectionDirection * ejectionForce);
    }
}
