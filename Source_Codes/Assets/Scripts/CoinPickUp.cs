using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : MonoBehaviour,IPickUp
{
    [SerializeField] int count;
    public void OnPickUp(Player player)
    {
        player.coins.AddCoin(count);
    }
}
