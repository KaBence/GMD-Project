using UnityEngine;

public class SlidingUpgrade : IUpgradeables
{
    public override bool CanUpgrade()
    {
        if (GetUpgradeValue() == 1)
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
        if (GetUpgradeValue() == 1)
        {
            buttonText.text = $"Sliding : Unlocked";
        }
        else
        {
            buttonText.text = $"Sliding : Locked (Cost: {GetUpgradeCost()})";
        }
        base.RefreshUI();
    }
}
