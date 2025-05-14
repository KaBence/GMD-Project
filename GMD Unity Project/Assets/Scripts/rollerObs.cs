using UnityEngine;

public class rollerObs : MonoBehaviour
{
    public float speed = 5f;
    public Vector3 direction = Vector3.forward;
    public float radius = 0.5f;
    void Update()
    {
        // Movement
        Vector3 movement = direction.normalized * speed * Time.deltaTime;
        transform.position -= movement;

        // Rotatation
        float distance = movement.magnitude;
        float angle = distance / (2 * Mathf.PI * radius) * 360f;

        Vector3 rotationAxis = Vector3.Cross(Vector3.up, direction).normalized;
        transform.Rotate(rotationAxis, angle, Space.World);
    }
}
