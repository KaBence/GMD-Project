using UnityEngine;

public class HandlePlayerSpeed : MonoBehaviour
{
    public float speed = 3f;
    public float jumpPower = 5f;
    public bool inWater = false;
    public bool IsRunning = false;

    // movement speed
    private float normalSpeed = 3f;
    private float runningSpeed = 6f;
    private float waterSpeed = 2f;
    private float runningWaterSpeed = 3.5f;

    // jump power
    private float normalJumpPower = 5f;
    private float waterJumpPower = 2.5f;

    private float runningJumpPower = 6f;
    private float runningWaterJumpPower = 3f;

    void Awake()
    {
        normalSpeed = PlayerPrefs.GetFloat(IUpgradeables.movementSpeedKey, 3f);
        runningSpeed = normalSpeed * 2f;
        waterSpeed = PlayerPrefs.GetFloat(IUpgradeables.waterSpeedKey, 2f);
        runningWaterSpeed = waterSpeed * 1.75f;
        normalJumpPower = PlayerPrefs.GetFloat(IUpgradeables.jumpForceKey, 5f);
        waterJumpPower = normalJumpPower * 0.5f;
        runningJumpPower = normalJumpPower * 1.2f;
        runningWaterJumpPower = waterJumpPower * 1.2f;
        UpdatePlayerSpeed();
    }


    private void setSpeed(float newSpeed, float newJumpPower)
    {
        speed = newSpeed;
        jumpPower = newJumpPower;
    }


    public void UpdatePlayerSpeed()
    {
        if (IsRunning && inWater)
            setSpeed(runningWaterSpeed, runningWaterJumpPower);
        else if (IsRunning)
            setSpeed(runningSpeed, runningJumpPower);
        else if (inWater)
            setSpeed(waterSpeed, waterJumpPower);
        else
            setSpeed(normalSpeed, normalJumpPower);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Water"))
        {
            inWater = true;
            UpdatePlayerSpeed();
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Water"))
        {
            inWater = false;
            UpdatePlayerSpeed();
        }
    }
}
