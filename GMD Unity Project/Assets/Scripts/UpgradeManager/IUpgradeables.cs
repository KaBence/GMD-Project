using TMPro;
using UnityEngine;

public abstract class IUpgradeables : MonoBehaviour
{
    public static string coinCountKey = "CoinCount";
    public static string waterSpeedKey = "WaterMovementSpeed";
    public static string jumpForceKey = "JumpForce";
    public static string healthKey = "Health";
    public static string movementSpeedKey = "MovementSpeed";
    public static string slidingKey = "Sliding";



    public enum UpgradeType
    {
        Health,
        MovementSpeed,
        WaterMovementSpeed,
        JumpForce,
        Sliding
    }

    [SerializeField] protected TextMeshProUGUI buttonText;
    [SerializeField] protected TextMeshProUGUI InfoText;
    
    [SerializeField] protected TextMeshProUGUI coinCountText;


    protected abstract int GetUpgradeCost();
    protected abstract string GetUpgradeString();
    protected abstract float GetUpgradeValue();

    public string GetUpgradeValueString()
    {
        return GetUpgradeValue().ToString();
    }

    public virtual void RefreshUI()
    {
        coinCountText.text = "Coins: "+ getCoinCount().ToString();
    }
    public virtual bool CanUpgrade()
    {
        if (getCoinCount() <= GetUpgradeCost())
        {
            Debug.Log("Not enough coins to upgrade " + GetUpgradeString() + ".");
            InfoText.text = "Not enough coins to upgrade " + GetUpgradeString() + ".\nYou need at least " + GetUpgradeCost() + " coins.";
            InfoText.color = Color.red;
            return false;
        }
        return true;
    }

    public void Upgrade()
    {
        if (!CanUpgrade())
            return;


        int coin = getCoinCount() - GetUpgradeCost();
        PlayerPrefs.SetInt(coinCountKey, coin);

        float upgradeValue = PlayerPrefs.GetFloat(GetUpgradeString(), 0f);
        PlayerPrefs.SetFloat(GetUpgradeString(), ++upgradeValue);
        Debug.Log(GetUpgradeString() + " upgraded to: " + upgradeValue);
        RefreshUI();
    }

    public int getCoinCount()
    {
        return PlayerPrefs.GetInt(coinCountKey, 9999);
    }

    protected virtual void Awake()
    {
        RefreshUI();
    }
    
}
