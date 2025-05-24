using System;
using TMPro;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    private int coinCount = 0;

    [SerializeField] private TextMeshProUGUI coinCountText;


    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            coinCount++;
            UpdateCoinCountText();
            Destroy(other.gameObject);
        }
    }

    private void UpdateCoinCountText()
    {
        coinCountText.text = "<sprite=0>: " + coinCount.ToString();
    }
}
