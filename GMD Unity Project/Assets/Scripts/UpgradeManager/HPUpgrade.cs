using UnityEngine;

public class HPUpgrade : IUpgradeables
{

    public override bool CanUpgrade()
    {
        if (GetUpgradeValue() >= 10)
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
        return 5 + GetUpgradeValue() * 2;
    }

    protected override string GetUpgradeString()
    {
        return healthKey;
    }

    protected override int GetUpgradeValue()
    {
        return PlayerPrefs.GetInt(GetUpgradeString(), 1);
    }

    public override void RefreshUI()
    {
        if (GetUpgradeValue() >= 10)
        {
            buttonText.text = $"HP Upgrade: {GetUpgradeValueString()} (Max Level)";
        }
        else
        {
            buttonText.text = $"HP Upgrade: {GetUpgradeValueString()} (Cost: {GetUpgradeCost()})";
        }
        base.RefreshUI();
    }
}
