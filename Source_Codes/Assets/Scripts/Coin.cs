using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] DataContainer data;
    [SerializeField] TMPro.TextMeshProUGUI coinsCountText;

    public void AddCoin(int count)
    {
        data.coins += count;
        coinsCountText.text = "COINS:" + data.coins.ToString();
    }
}
