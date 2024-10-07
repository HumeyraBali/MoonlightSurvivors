using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public string Name;
    public int armor;

    public void Equip(Player player)
    {
        player.armor += armor;
    }

    public void UnEquip(Player player)
    {
        player.armor -= armor;
    }
}
