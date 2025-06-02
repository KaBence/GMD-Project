using UnityEngine;

public class WaterSpeedUpgrade : IUpgradeables
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
        return waterSpeedKey;
    }

    protected override float GetUpgradeValue()
    {
        return PlayerPrefs.GetFloat(GetUpgradeString(), 2);
    }

    public override void RefreshUI()
    {
        if (GetUpgradeValue() >= getMaxUpgradeValue())
        {
            buttonText.text = $"Water Speed Upgrade: {GetUpgradeValueString()} (Max Level)";
        }
        else
        {
            buttonText.text = $"Water Speed Upgrade: {GetUpgradeValueString()} (Cost: {GetUpgradeCost()})";
        }
        base.RefreshUI();
    }

    protected override int getMaxUpgradeValue()
    {
        return 4;
    }
}
