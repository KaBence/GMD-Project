using TMPro;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField] private int maxHealth = 1;
    [SerializeField] private int currentHealth;

    [SerializeField] private TextMeshProUGUI HPText;


    private void Awake()
    {
        currentHealth = maxHealth;
        HPText.text = "<sprite=0> : " + currentHealth.ToString();

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("HIT!");
            TakeDamage(1);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        HPText.text = "<sprite=0> : " + currentHealth.ToString();

        if (currentHealth <= 0)
            Die();
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth; // Ensure health doesn't exceed max
        HPText.text = "<sprite=0> : " + currentHealth.ToString();
    }



    private void Die()
    {
        Debug.Log("Player has died.");
        currentHealth = 0; // Ensure health doesn't go below zero
        HPText.text = "<sprite=0> : " + currentHealth.ToString();
        Destroy(gameObject);
    }
}
