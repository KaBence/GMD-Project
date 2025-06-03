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
        maxHealth = PlayerPrefs.GetFloat(IUpgradeables.healthKey, 1);
        currentHealth = maxHealth;
        HPText.text = "<sprite=0> : " + currentHealth.ToString();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("HIT!");
            TakeDamage(1);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Lava"))
        {
            Debug.Log("HIT!");
            TakeDamage(1);
        }
        else
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
        CameraShake.Instance.ShakeCamera(0.1f, 0.1f); 
        if (currentHealth <= 0)
            Die();
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth; 
        HPText.text = "<sprite=0> : " + currentHealth.ToString();
    }



    private void Die()
    {
        Debug.Log("Player has died.");
        currentHealth = 0;
        HPText.text = "<sprite=0> : " + currentHealth.ToString();
        deathSceneUI.ShowDeathPopup();
    }
}
