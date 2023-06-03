using UnityEngine;

public class CircularFlight : MonoBehaviour
{
    public float radius = 5f;
    public float speed = 2f;
    private float currentAngle = 0f;

    private Animator animator;

    public Transform centerPoint;


    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Set the "Fly" trigger
        animator.SetTrigger("FlyAnim");

        // Increment the angle based on the speed and time
        currentAngle += speed * Time.deltaTime;

        // Calculate the new position based on the angle and radius
        Vector3 center = centerPoint.position;
        float x = center.x + Mathf.Cos(currentAngle) * radius;
        float y = center.y;
        float z = center.z + Mathf.Sin(currentAngle) * radius;

        // Set the new position
        transform.position = new Vector3(x, y, z);

        // Calculate the look rotation based on the movement direction
        Vector3 lookDirection = new Vector3(Mathf.Sin(currentAngle), 0f, Mathf.Cos(currentAngle));
        Quaternion lookRotation = Quaternion.LookRotation(lookDirection, Vector3.up);

        // Apply the rotation to the bird model
        transform.rotation = lookRotation;
    }
}

