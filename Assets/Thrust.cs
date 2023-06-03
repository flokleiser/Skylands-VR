using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.XR.Interaction.Toolkit.Inputs;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Assertions;
using UnityEngine.Serialization;
using Unity.XR.CoreUtils;



namespace UnityEngine.XR.Interaction.Toolkit
{
    public abstract class Thrust : LocomotionProvider
    {


        [SerializeField]
        InputDevice m_Device;
        public InputDevice device
        {
            get => m_Device;
            set => m_Device = value;
        }

        [SerializeField]
        [Tooltip("Controls whether to enable strafing (sideways movement).")]
        bool m_EnableStrafe = true;
        /// <summary>
        /// Controls whether to enable strafing (sideways movement).
        /// </summary>
        public bool enableStrafe
        {
            get => m_EnableStrafe;
            set => m_EnableStrafe = value;
        }


        public float speed = 0.8f;
        private bool isFlying = false;

        //chatgpt

        public float fallSpeed = 5f; // Adjustable falling speed

        [SerializeField]
        [Tooltip("The source Transform to define the forward direction.")]
        Transform m_ForwardSource;
        public Transform ForwardSource
        {
            get => m_ForwardSource;
            set => m_ForwardSource = value;
        }

        public CharacterController m_CharacterController;

        //audio test start

        public AudioSource audioSource;
        public AudioClip ThrustSound;

        //audio test end

        // Update is called once per frame
        void Update()
        {
            CheckIfFlying();
            FlyIfFlying();

        }




        Vector3 m_VerticalVelocity;

        protected abstract float ReadInput();


        private void CheckIfFlying()
        {
            float input = ReadInput();
            if (input > 0)
            {
                isFlying = true;
                if (audioSource != null && ThrustSound != null && !audioSource.isPlaying)
                {
                    audioSource.clip = ThrustSound;
                    audioSource.Play();
                }

            }
            else
            {
                isFlying = false;
                if (audioSource != null && audioSource.isPlaying)
                {
                    audioSource.Stop();
                }

            }
        }


        private void FlyIfFlying()
        {
            // script before chatgpt

            var xrOrigin = system.xrOrigin;
            if (xrOrigin == null)
                return;

            if (m_CharacterController != null)
            {

                //chatgpt
               

                if (isFlying)
                {
                    var direction = m_ForwardSource.forward;
                    float verticalSpeed = m_VerticalVelocity.y;

                    var motion = (direction.normalized * speed) + (Vector3.up * verticalSpeed);


                    xrOrigin.Origin.transform.position += motion;

                    //chatgot


                }
                else
                {
                    // Apply falling due to gravity
                    var fallMotion = m_VerticalVelocity * fallSpeed * Time.deltaTime;

                    xrOrigin.Origin.transform.position += fallMotion;





                }
            }

        }


    }
}