using UnityEngine;

public class AudioController : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField] private AudioClip runAudioClip;
    private PlayerMovement playerMovement;



    void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();

        audioSource = GetComponent<AudioSource>();

    }

    void Update()
    {

        bool isRunning = playerMovement.movement != Vector2.zero && playerMovement.IsGrounded();

        if (isRunning && !audioSource.isPlaying)
        {
            Debug.Log("Playing run audio");
            audioSource.clip = runAudioClip;
            audioSource.loop = true;

            audioSource.Play();
        }
        else if (!isRunning && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}
