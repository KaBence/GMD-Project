using UnityEngine;

public class ItemMoveupDown : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 0.5f;
    [SerializeField] private float moveDistance = 0.5f;

    void Update()
    {
        // Move the item up and down
        float newY = Mathf.PingPong(Time.time * moveSpeed, moveDistance);
        transform.localPosition = new Vector3(transform.localPosition.x, newY+1f, transform.localPosition.z);
    }
}
