using System;
using TMPro;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    private int AllcoinCount;

    private int coinCount = 0;

    [SerializeField] private TextMeshProUGUI coinCountText;


    private void Awake()
    {
        AllcoinCount = PlayerPrefs.GetInt("CoinCount", 0);
        UpdateCoinCountText();
    }

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

    private void OnDisable()
    {
        PlayerPrefs.SetInt("CoinCount", coinCount + AllcoinCount);
        PlayerPrefs.Save();
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("CoinCount", coinCount + AllcoinCount);
        PlayerPrefs.Save();
    }
}
