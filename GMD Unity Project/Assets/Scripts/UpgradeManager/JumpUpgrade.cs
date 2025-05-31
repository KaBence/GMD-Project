using UnityEngine;

public class JumpUpgrade : IUpgradeables
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
        return 5 + Mathf.CeilToInt(GetUpgradeValue()) * 2;
    }

    protected override string GetUpgradeString()
    {
        return jumpForceKey;
    }

    protected override float GetUpgradeValue()
    {
        return PlayerPrefs.GetFloat(GetUpgradeString(), 5);
    }

    public override void RefreshUI()
    {
        if (GetUpgradeValue() >= 10)
        {
            buttonText.text = $"Jump Upgrade: {GetUpgradeValueString()} (Max Level)";
        }
        else
        {
            buttonText.text = $"Jump Upgrade: {GetUpgradeValueString()} (Cost: {GetUpgradeCost()})";
        }
        base.RefreshUI();
    }
}
