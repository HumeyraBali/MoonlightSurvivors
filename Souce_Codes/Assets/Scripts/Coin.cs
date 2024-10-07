using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinAcquired;
    [SerializeField] TMPro.TextMeshProUGUI coinsCountText;

    public void AddCoin(int count)
    {
        coinAcquired += count;
        coinsCountText.text = "COINS:" + coinAcquired.ToString();
    }
}
