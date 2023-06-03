using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Inputs;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;


public class ActionBasedThrust : Thrust
{
    /*
    // Use this when grip input if on the left hand
    [SerializeField]
    InputActionProperty m_LeftHandThrustAction;
   
    public InputActionProperty leftHandThrustAction
    {
        get => m_LeftHandThrustAction;
        set => SetInputActionProperty(ref m_LeftHandThrustAction, value);
    }
    */

    // Use this when grip input if on the right hand
    [SerializeField]
    InputActionProperty m_LeftHandThrustAction;

    public InputActionProperty LeftHandThrustAction
    {
        //get => m_LeftHandThrustAction;
        //set => SetInputActionProperty(ref m_LeftHandThrustAction, value);

        get => m_LeftHandThrustAction;
        set => SetInputActionProperty(ref m_LeftHandThrustAction, value);
    }

    protected override float ReadInput()
    {
        // script before ChatGPT
        
            //var leftHandValue = m_LeftHandThrustAction.action?.ReadValue<float>() ?? 0.0f;
            var leftHandValue = m_LeftHandThrustAction.action?.ReadValue<float>() ?? 0.0f;

            return leftHandValue;
        



    }

    void SetInputActionProperty(ref InputActionProperty property, InputActionProperty value)
    {
        if (Application.isPlaying)
            property.DisableDirectAction();

        property = value;

        if (Application.isPlaying && isActiveAndEnabled)
            property.EnableDirectAction();
    }
    protected void OnEnable()
    {
        m_LeftHandThrustAction.EnableDirectAction();
    }

    protected void OnDisable()
    {
        m_LeftHandThrustAction.DisableDirectAction();
    }
}

