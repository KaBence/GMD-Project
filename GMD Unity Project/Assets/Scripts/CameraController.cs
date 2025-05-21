using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Camera cam;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float verticalMargin = 0.05f;

    void Awake()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Move the camera forward
        // transform.position += Vector3.forward * speed * Time.deltaTime;

        // Convert player world position to viewport space (0 to 1)
        Vector3 viewPos = cam.WorldToViewportPoint(player.transform.position);

        // If the player is outside the margins, nudge them back in
        if (viewPos.y < verticalMargin)
            viewPos.y = verticalMargin;
        else if (viewPos.y > 1f - verticalMargin)
            viewPos.y = 1f - verticalMargin;

        // Convert back to world space
        Vector3 correctedWorldPos = cam.ViewportToWorldPoint(viewPos);

        // Keep player's Y position (so jumping etc. still works)
        correctedWorldPos.y = player.transform.position.y;

        player.transform.position = correctedWorldPos;
    }
}
