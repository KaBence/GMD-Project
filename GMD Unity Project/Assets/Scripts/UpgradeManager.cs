using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    private string coinCountKey = "CoinCount";
    public enum UpgradeType
    {
        Health,
        MovementSpeed,
        WaterMovementSpeed,
        JumpForce,
        Sliding
    }


    [SerializeField] private TextMeshProUGUI CoinCountText;
    [SerializeField] private TextMeshProUGUI MaxHealthText;
    [SerializeField] private TextMeshProUGUI SlidingUnlockedText;
    [SerializeField] private TextMeshProUGUI MovementSpeedText;
    [SerializeField] private TextMeshProUGUI WaterMovementSpeedText;
    [SerializeField] private TextMeshProUGUI JumpForceText;
    [SerializeField] private TextMeshProUGUI InfoText;


    private void Awake()
    {
        RefreshUI();
    }

    void Upgrade(UpgradeType upgradeType)
    {
        if (!CanUpgrade(upgradeType))
            return;


        int coin = getCoinCount() - GetUpgradeValue(upgradeType) * 2;
        PlayerPrefs.SetInt(coinCountKey, coin);

        int upgradeValue = PlayerPrefs.GetInt(upgradeType.ToString(), 0);
        PlayerPrefs.SetInt(upgradeType.ToString(), ++upgradeValue);
        Debug.Log(upgradeType.ToString() + " upgraded to: " + upgradeValue);
        RefreshUI();
    }

    private bool CanUpgrade(UpgradeType upgradeType)
    {
        if (getCoinCount() <= GetUpgradeValue(upgradeType) * 2)
        {
            Debug.Log("Not enough coins to upgrade " + upgradeType.ToString() + ".");
            InfoText.text = "Not enough coins to upgrade " + upgradeType.ToString() + ".\nYou need at least " + GetUpgradeValue(upgradeType) * 2 + " coins.";
            InfoText.color = Color.red;
            return false;
        }

        if (upgradeType == UpgradeType.Sliding && GetUpgradeString(UpgradeType.Sliding) == "Unlocked")
        {
            Debug.Log("Sliding is already unlocked.");
            InfoText.text = "Sliding is already unlocked.";
            InfoText.color = Color.yellow;
            return false;
        }

        return true;
    }


    private void RefreshUI()
    {
        CoinCountText.text = getCoinCount().ToString();
        MaxHealthText.text = "Max Health\n" + GetUpgradeString(UpgradeType.Health);
        MovementSpeedText.text = "Movement Speed\n" + GetUpgradeString(UpgradeType.MovementSpeed);
        WaterMovementSpeedText.text = "Water Speed\n" + GetUpgradeString(UpgradeType.WaterMovementSpeed);
        JumpForceText.text = "Jump Force\n" + GetUpgradeString(UpgradeType.JumpForce);
        SlidingUnlockedText.text = "Sliding\n" + GetUpgradeString(UpgradeType.Sliding);
    }


    public void UpgradeHealth() => Upgrade(UpgradeType.Health);
    public void UpgradeMovementSpeed() => Upgrade(UpgradeType.MovementSpeed);
    public void UpgradeWaterMovementSpeed() => Upgrade(UpgradeType.WaterMovementSpeed);
    public void UpgradeJumpForce() => Upgrade(UpgradeType.JumpForce);
    public void UpgradeSliding() => Upgrade(UpgradeType.Sliding);

    public void ResetUpgrades()
    {
        PlayerPrefs.SetInt(coinCountKey, 9999);
        PlayerPrefs.SetInt(UpgradeType.Health.ToString(), 1);
        PlayerPrefs.SetInt(UpgradeType.MovementSpeed.ToString(), 3);
        PlayerPrefs.SetInt(UpgradeType.WaterMovementSpeed.ToString(), 2);
        PlayerPrefs.SetInt(UpgradeType.JumpForce.ToString(), 5);
        PlayerPrefs.SetInt(UpgradeType.Sliding.ToString(), 0);
        RefreshUI();
    }

    // Helper methods
    private int getCoinCount()
    {
        return PlayerPrefs.GetInt(coinCountKey, 9999);
    }

    private string GetUpgradeString(UpgradeType upgradeType)
    {
        return GetUpgradeValue(upgradeType).ToString();
    }

    private int GetUpgradeValue(UpgradeType upgradeType)
    {
        return upgradeType switch
        {
            UpgradeType.Health => PlayerPrefs.GetInt(UpgradeType.Health.ToString(), 1),
            UpgradeType.MovementSpeed => PlayerPrefs.GetInt(UpgradeType.MovementSpeed.ToString(), 3),
            UpgradeType.WaterMovementSpeed => PlayerPrefs.GetInt(UpgradeType.WaterMovementSpeed.ToString(), 2),
            UpgradeType.JumpForce => PlayerPrefs.GetInt(UpgradeType.JumpForce.ToString(), 5),
            UpgradeType.Sliding => PlayerPrefs.GetInt(UpgradeType.Sliding.ToString(), 0),
            _ => -1,
        };
    }
}
