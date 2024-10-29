using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemStats
{
    public int armor;

    internal void Sum(ItemStats stats)
    {
        armor += stats.armor;
    }
}

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public string Name;
    public int armor;
    public ItemStats stats;
    public List<UpgradeData> upgrades;

    public void Init(string Name)
    {
        this.Name = Name;
        stats = new ItemStats();
        upgrades = new List<UpgradeData>();
    }

    public void Equip(Player player)
    {
        player.armor += stats.armor;
    }

    public void UnEquip(Player player)
    {
        player.armor -= stats.armor;
    }
}
