using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveItems : MonoBehaviour
{
    [SerializeField] List<Item> items;

    Player player;

    private void Awake() 
    {
        player = GetComponent<Player>();
    }

    void Start()
    {
        
    }

    public void Equip(Item itemToEquip)
    {
        if (items == null) { items = new List<Item>(); }

        Item newItemInstance = new Item();
        newItemInstance.Init(itemToEquip.Name);
        newItemInstance.stats.Sum(itemToEquip.stats);

        items.Add(newItemInstance);
        newItemInstance.Equip(player);
    }

    public void UnEquip(Item itemToUnEquip)
    {

    }

    internal void UpgradeItem(UpgradeData upgradeData)
    {
        Item itemToUpgrade = items.Find(id => id.Name == upgradeData.item.Name);
        itemToUpgrade.UnEquip(player);
        itemToUpgrade.stats.Sum(upgradeData.itemStats);
        itemToUpgrade.Equip(player);
    }
}
