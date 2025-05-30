using TMPro;
using UnityEngine;

public class ResetUpgrades : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI InfoText;

    private HPUpgrade hpUpgrade;
    private MoveSpeedUpgrade movementSpeedUpgrade;
    private WaterSpeedUpgrade waterMovementSpeedUpgrade;
    private JumpUpgrade jumpUpgrade;
    private SlidingUpgrade slidingUpgrade;


    void Awake()
    {
        hpUpgrade = GetComponent<HPUpgrade>();
        movementSpeedUpgrade = GetComponent<MoveSpeedUpgrade>();
        waterMovementSpeedUpgrade = GetComponent<WaterSpeedUpgrade>();
        jumpUpgrade = GetComponent<JumpUpgrade>();
        slidingUpgrade = GetComponent<SlidingUpgrade>();
        RefreshUI();
    }

    public void ResetUpgrade()
    {
        PlayerPrefs.SetInt(IUpgradeables.coinCountKey, 9999);
        PlayerPrefs.SetInt(IUpgradeables.healthKey, 1);
        PlayerPrefs.SetInt(IUpgradeables.movementSpeedKey, 3);
        PlayerPrefs.SetInt(IUpgradeables.waterSpeedKey, 2);
        PlayerPrefs.SetInt(IUpgradeables.jumpForceKey, 5);
        PlayerPrefs.SetInt(IUpgradeables.slidingKey, 0);
        RefreshUI();
        Debug.Log("All upgrades reset to default values.");
        InfoText.text = "Upgrades reset to default values.";
    }

    private void RefreshUI()
    {
        hpUpgrade.RefreshUI();
        movementSpeedUpgrade.RefreshUI();
        waterMovementSpeedUpgrade.RefreshUI();
        jumpUpgrade.RefreshUI();
        slidingUpgrade.RefreshUI();
    }
}
