using UnityEngine;

public class Lantern : MonoBehaviour
{
    private Light lightSource;

    private void Start()
    {
        lightSource = GetComponent<Light>(); // Get the reference to the Light component attached to the GameObject
        lightSource.enabled = false; // Disable the light source
    }
}
