using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPickUp : MonoBehaviour,IPickUp
{
    [SerializeField] int healAmount;

    public void OnPickUp(Player player)
    {
        player.Heal(healAmount);
    }
}
