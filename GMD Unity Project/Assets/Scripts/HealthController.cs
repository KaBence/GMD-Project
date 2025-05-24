using TMPro;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth;

    [SerializeField] private TextMeshProUGUI HPText;


    private void Awake()
    {
        currentHealth = maxHealth;
        HPText.text = "HP: " + currentHealth.ToString();

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("HIT!");
            TakeDamage(10);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        HPText.text = "HP: " + currentHealth.ToString();
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth; // Ensure health doesn't exceed max
        }
        HPText.text = "HP: " + currentHealth.ToString();
    }

    

    private void Die()
    {
        Debug.Log("Player has died.");
        // Here you can add logic for player death, like respawning or ending the game.
        currentHealth = 0; // Ensure health doesn't go below zero
        HPText.text = "HP: " + currentHealth.ToString();

        Destroy(gameObject); // Optionally destroy the player object
    }
}
