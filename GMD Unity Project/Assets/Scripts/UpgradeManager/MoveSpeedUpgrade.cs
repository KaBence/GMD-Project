using UnityEngine;

public class MoveSpeedUpgrade : IUpgradeables
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
        return movementSpeedKey;
    }

    protected override int GetUpgradeValue()
    {
        return PlayerPrefs.GetInt(GetUpgradeString(), 3);
    }

    public override void RefreshUI()
    {
        if (GetUpgradeValue() >= 10)
        {
            buttonText.text = $"Move Speed Upgrade: {GetUpgradeValueString()} (Max Level)";
        }
        else
        {
            buttonText.text = $"Move Speed Upgrade: {GetUpgradeValueString()} (Cost: {GetUpgradeCost()})";
        }
        base.RefreshUI();
    }
}
