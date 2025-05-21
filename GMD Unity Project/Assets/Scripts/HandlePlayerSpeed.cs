using UnityEngine;

public class HandlePlayerSpeed : MonoBehaviour
{
    public float speed = 5f;
    public float jumpPower = 5f;
    public bool inWater = false;
    public bool IsRunning = false;

    // movement speed
    private float normalSpeed = 5f;
    private float runningSpeed = 10f;
    private float waterSpeed = 3.5f;
    private float runningWaterSpeed = 5f;

    // jump power
    private float normalJumpPower = 5f;
    private float waterJumpPower = 2.5f;

    private float runningJumpPower = 7f;
    private float runningWaterJumpPower = 4f;


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
