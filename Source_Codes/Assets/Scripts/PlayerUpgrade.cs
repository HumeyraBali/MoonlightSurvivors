using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUpgrade : MonoBehaviour
{
    [SerializeField] PlayerPersistentUprades upgrade;

    [SerializeField] TextMeshProUGUI upgradeName;
    [SerializeField] TextMeshProUGUI level;
    [SerializeField] TextMeshProUGUI price;

    [SerializeField] DataContainer dataContainer;

    private void Start() 
    {
        UpdateElement();
    }

    public void Upgrade()
    {
        PlayerUpgrades playerUpgrades = dataContainer.upgrades[(int)upgrade];

        if (playerUpgrades.level >= playerUpgrades.maxLevel) { return; }
        if(dataContainer.coins >= playerUpgrades.costToUpgrade)
        {
            dataContainer.coins -= playerUpgrades.costToUpgrade;
            playerUpgrades.level += 1;
            UpdateElement();
        }
    }

    void UpdateElement()
    {
        PlayerUpgrades playerUpgrade = dataContainer.upgrades[(int)upgrade];

        upgradeName.text = "Upgrade " + upgrade.ToString();
        level.text = "Level: " + playerUpgrade.level.ToString();
        price.text = "Price: " + playerUpgrade.costToUpgrade.ToString();
    }

}
