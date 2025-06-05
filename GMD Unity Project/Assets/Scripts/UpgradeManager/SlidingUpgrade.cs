using UnityEngine;

public class SlidingUpgrade : IUpgradeables
{
    public override bool CanUpgrade()
    {
        if (GetUpgradeValue() == getMaxUpgradeValue())
        {
            Debug.Log($"{GetUpgradeString()} is already unlocked.");
            InfoText.text = $"{GetUpgradeString()} is already unlocked.";
            InfoText.color = Color.yellow;
            return false;
        }

        if (!base.CanUpgrade())
        {
            return false;
        }

        return true;
    }


    protected override int GetUpgradeCost()
    {
        return GetUpgradeValue() == 0 ? 20 : 0;
    }

    protected override string GetUpgradeString()
    {
        return slidingKey;
    }

    protected override float GetUpgradeValue()
    {
        return PlayerPrefs.GetFloat(GetUpgradeString(), 0);
    }

    public override void RefreshUI()
    {
        if (GetUpgradeValue() == getMaxUpgradeValue())
        {
            buttonText.text = $"Sliding : Unlocked";
        }
        else
        {
            buttonText.text = $"Sliding : Locked (Cost: {GetUpgradeCost()})";
        }
        base.RefreshUI();
    }

    public override void Upgrade()
    {
        if (!CanUpgrade())
            return;
        int coin = getCoinCount() - GetUpgradeCost();
        PlayerPrefs.SetInt(coinCountKey, coin);

        PlayerPrefs.SetFloat(GetUpgradeString(), 1);
        RefreshUI();
        InfoText.text = $"{GetUpgradeString()} unlocked!";
        InfoText.color = Color.green;
        Debug.Log($"{GetUpgradeString()} unlocked!");
    }

    protected override int getMaxUpgradeValue()
    {
        return 1;
    }
}
