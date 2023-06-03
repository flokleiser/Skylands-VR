using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class VRJumpButton : MonoBehaviour
{
    public VRJump jumpScript;

    private XRController controller;
    private OnButtonPress onButtonPress;

    private void Start()
    {
        controller = GetComponent<XRController>();
        onButtonPress = GetComponent<OnButtonPress>();
        onButtonPress.OnPress.AddListener(Jump);
    }

    private void OnDestroy()
    {
        onButtonPress.OnPress.RemoveListener(Jump);
    }

    private void Jump()
    {
        // Trigger a jump by calling the Jump method on the VRJump script
        jumpScript.Jump();
    }
}
