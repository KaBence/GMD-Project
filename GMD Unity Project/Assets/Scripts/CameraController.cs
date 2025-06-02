using UnityEngine;

public class CameraController : MonoBehaviour
{
    private HealthController healthController;
    private Camera cam;
    [SerializeField] private GameObject player;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float verticalMargin = 0.05f;



    [SerializeField] private float outOfBoundsDamageCooldown = 1f; // seconds
    private float outOfBoundsTimer = 0f;
    void Awake()
    {
        cam = GetComponent<Camera>();
        healthController = player.GetComponent<HealthController>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Move the camera forward
        transform.position += Vector3.forward * speed * Time.deltaTime;

        // Convert player world position to viewport space (0 to 1)
        Vector3 viewPos = cam.WorldToViewportPoint(player.transform.position);

        bool outOfBounds = viewPos.y < verticalMargin || viewPos.y > 1f - verticalMargin;

        if (outOfBounds)
        {
            outOfBoundsTimer -= Time.deltaTime;
            if (outOfBoundsTimer <= 0f)
            {
                healthController.TakeDamage(1);
                outOfBoundsTimer = outOfBoundsDamageCooldown;
            }
        }
        else
        {
            // Reset the timer only when the player returns to bounds
            outOfBoundsTimer = 0f;
        }
    }
}
