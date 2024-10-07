using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemPickUp : MonoBehaviour,IPickUp
{
    [SerializeField] int amount;

    public void OnPickUp(Player player)
    {
        player.level.AddExperience(amount);
    }
}
