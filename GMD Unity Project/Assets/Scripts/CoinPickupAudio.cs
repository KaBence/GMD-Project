using UnityEngine;

public class CoinPickupAudio : MonoBehaviour
{
    private AudioSource audioSource;


    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            audioSource.Play();
            GetComponent<Collider>().enabled = false;
            foreach (var renderer in GetComponentsInChildren<Renderer>())
            {
                renderer.enabled = false;
            }
            Destroy(gameObject, audioSource.clip.length);
        }
    }
}

