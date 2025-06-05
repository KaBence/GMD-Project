using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent navMeshAgent;

    private Animator animator;

    private int isPlayerFoundHash;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        isPlayerFoundHash = Animator.StringToHash("isPlayerFound");
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Vector3 directionToPlayer = player.position - transform.position;
            float distanceToPlayer = directionToPlayer.magnitude;

            RaycastHit hit;
            // Cast a ray towards the player
            if (Physics.Raycast(transform.position, directionToPlayer.normalized, out hit, distanceToPlayer))
            {
                // Check if the raycast hit the player
                if (hit.transform == player)
                {
                    animator.SetBool(isPlayerFoundHash, true);
                    navMeshAgent.SetDestination(player.position);
                }
            }
        }
    }
}
