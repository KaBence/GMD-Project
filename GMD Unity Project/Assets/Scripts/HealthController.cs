using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class HealthController : MonoBehaviour
{
    private float maxHealth;
    [SerializeField] private float currentHealth;

    [SerializeField] private TextMeshProUGUI HPText;

    [SerializeField] private DeathSceneUI deathSceneUI;
    [SerializeField] private WinScene winScene;


    private void Awake()
    {
        maxHealth = PlayerPrefs.GetFloat(IUpgradeables.healthKey, 10);
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

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FallDetector"))
        {
            Debug.Log("Fell off the map!");
            Die();
        }
        else if (other.gameObject.CompareTag("WinDetector"))
        {
            Debug.Log("Reached the end!");
            winScene.ShowWinPopup();
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        HPText.text = "<sprite=0> : " + currentHealth.ToString();
        CameraShake.Instance.ShakeCamera(0.1f, 0.1f); // Shake the camera on hit
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
        deathSceneUI.ShowDeathPopup();
    }
}
