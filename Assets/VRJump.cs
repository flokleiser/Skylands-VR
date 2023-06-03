using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class VRJump : MonoBehaviour
{
    [SerializeField] XROrigin m_XROrigin;

    public XROrigin xrOrigin
    {
        get => m_XROrigin;
        set => m_XROrigin = value;
    }


    public float jumpForce = 5f;
    private bool isJumping = false;

    public void Jump()
    {
        if (!isJumping)
        {
            // Add a vertical force to the player's Rigidbody component
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            isJumping = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Reset the isJumping flag when the player lands on a surface
        if (isJumping)
        {
            isJumping = false;
        }
    }
}
