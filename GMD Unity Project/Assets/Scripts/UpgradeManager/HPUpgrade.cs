using UnityEngine;

public class HPUpgrade : IUpgradeables
{

    public override bool CanUpgrade()
    {
        if (GetUpgradeValue() >= getMaxUpgradeValue())
        {
            Debug.Log(GetUpgradeString() + " is already at max level.");
            InfoText.text = GetUpgradeString() + " is already at max level.";
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
        return Mathf.CeilToInt(5 + GetUpgradeValue() * 2);
    }

    protected override string GetUpgradeString()
    {
        return healthKey;
    }

    protected override float GetUpgradeValue()
    {
        return PlayerPrefs.GetFloat(GetUpgradeString(), 1);
    }

    public override void RefreshUI()
    {
        if (GetUpgradeValue() >= getMaxUpgradeValue())
        {
            buttonText.text = $"HP Upgrade: {GetUpgradeValueString()} (Max Level)";
        }
        else
        {
            buttonText.text = $"HP Upgrade: {GetUpgradeValueString()} (Cost: {GetUpgradeCost()})";
        }
        base.RefreshUI();
    }

    public override void Upgrade()
    {
        if (!CanUpgrade())
            return;
        int coin = getCoinCount() - GetUpgradeCost();
        PlayerPrefs.SetInt(coinCountKey, coin);

        PlayerPrefs.SetFloat(GetUpgradeString(), GetUpgradeValue() + 1);
        RefreshUI();
    }

    protected override int getMaxUpgradeValue()
    {
        return 5;
    }
}
