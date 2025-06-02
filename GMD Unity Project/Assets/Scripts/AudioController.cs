using UnityEngine;

public class AudioController : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField] private AudioClip runAudioClip;
    [SerializeField] private AudioClip jumpAudioClip;
    private PlayerMovement playerMovement;
    private bool wasGrounded = true;


    void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();

        audioSource = GetComponent<AudioSource>();

    }

    void Update()
    {

        // bool isRunning = playerMovement.movement != Vector2.zero && playerMovement.IsGrounded();

        // if (isRunning && !audioSource.isPlaying)
        // {
        //     Debug.Log("Playing run audio");
        //     audioSource.clip = runAudioClip;
        //     audioSource.loop = true;

        //     audioSource.Play();
        // }
        // else if (!isRunning && audioSource.isPlaying)
        // {
        //     audioSource.Stop();
        // }
        // bool isGrounded = playerMovement.IsGrounded();

        // // Play jump sound only when leaving the ground
        // if (wasGrounded && !isGrounded)
        // {
        //     audioSource.clip = jumpAudioClip;
        //     audioSource.loop = false;
        //     audioSource.Play();
        // }

        // // Optionally stop jump sound when landing
        // if (!wasGrounded && isGrounded && audioSource.isPlaying && audioSource.clip == jumpAudioClip)
        // {
        //     audioSource.Stop();
        // }

        // wasGrounded = isGrounded;
    }
}
