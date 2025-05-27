using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour
{
    [SerializeField] private Transform pivot;
    [SerializeField] private float speed = 80f;
    [SerializeField] private Vector3 axis;
    [SerializeField] private float maxAngle = 75f; // degrees
    private float currentAngle = 0f;
    private int direction = 1; // 1 or -1


    // Rotates the object around a pivot point in a back-and-forth motion. 
    // if the max angle is 360, it will rotate continuously.

    private void Start()
    {
        // Pick a random starting angle between -maxAngle and maxAngle
        float randomStartAngle = Random.Range(-maxAngle, maxAngle);
        transform.RotateAround(pivot.position, axis, randomStartAngle);
        currentAngle = randomStartAngle;

        StartCoroutine(RotateBackAndForth());
    }

    private IEnumerator RotateBackAndForth()
    {
        while (true)
        {
            // Apply rotation
            float deltaAngle = speed * Time.deltaTime * direction;
            transform.RotateAround(pivot.position, axis, deltaAngle);

            if (maxAngle == 360)
            {
                yield return null;
                continue;
            }

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
