using UnityEngine;
using System.Collections;

public class RotateAround : MonoBehaviour
{
    [SerializeField] private Transform pivot;
    [SerializeField] private float speed = 80f;
    [SerializeField] private Vector3 axis;
    [SerializeField] private float maxAngle = 75f; // degrees
    private float currentAngle = 0f;
    private int direction = 1; // 1 or -1


    private void Start()
    {
        StartCoroutine(RotateBackAndForth());
    }

    private IEnumerator RotateBackAndForth()
    {
        while (true)
        {
            float deltaAngle = speed * Time.deltaTime * direction;

            // Apply rotation
            transform.RotateAround(pivot.position, axis, deltaAngle);

            // Track angle
            currentAngle += deltaAngle;

            // Clamp and reverse
            if (Mathf.Abs(currentAngle) >= maxAngle)
            {
                direction *= -1;
                currentAngle = Mathf.Clamp(currentAngle, -maxAngle, maxAngle);
            }

            yield return null;
        }
    }
}
