using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Level : MonoBehaviour
{
    int level = 1;
    int experience = 0;
    [SerializeField] ExperienceBar experienceBar;
    [SerializeField] UpgradePanelManager upgradePanel;

    [SerializeField] List<UpgradeData> upgrades;
    List<UpgradeData> selectedUpgrades;
    [SerializeField] List<UpgradeData> acquiredUpgarades;
    [SerializeField] List<UpgradeData> upgradesAvaibleOnStart;
    [SerializeField] DataContainer dataContainer;


    WeaponManager weaponManager;
    PassiveItems passiveItems;
    Player player;


    private void Awake() 
    {
        weaponManager = GetComponent<WeaponManager>();
        passiveItems = GetComponent<PassiveItems>();
        player = gameObject.GetComponent<Player>();
    }

    int TO_LEVEL_UP
    {
        get
        {
            return level*1000;
        }
    }

    private void Start() 
    {
        experienceBar.UpdateExperienceSlider(experience, TO_LEVEL_UP);
        experienceBar.SetLevelText(level);
        AddUpgradesIntoTheListOfAvalibleUpgrades(upgradesAvaibleOnStart);
        
        WeaponData startingWeapon = dataContainer.selectedPlayer.startingWeapon;
        RemoveStartingWeaponUnlockUpgrade(startingWeapon);
    }

    private void RemoveStartingWeaponUnlockUpgrade(WeaponData startingWeapon)
    {
        if (startingWeapon != null)
        {
            // Find the UpgradeData that matches the starting weapon and is of type WeaponUnlock
            UpgradeData upgradeToRemove = upgrades.Find(upgrade =>
                upgrade.weaponData == startingWeapon && 
                upgrade.upgradeType == UpgradeType.WeaponUnlock);

            // If found, remove it from the list
            if (upgradeToRemove != null)
            {
                upgrades.Remove(upgradeToRemove);
            }
        }
    }

    public void AddExperience(int amount)
    {
        experience += amount;
        CheckLevelUp();
        experienceBar.UpdateExperienceSlider(experience, TO_LEVEL_UP);
    }

    private void CheckLevelUp()
    {
        if (experience >= TO_LEVEL_UP)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        if (selectedUpgrades == null) {selectedUpgrades = new List<UpgradeData>();}
        selectedUpgrades.Clear();
        selectedUpgrades.AddRange(GetUpgrades(4));

        upgradePanel.OpenPanel(selectedUpgrades);
        experience -= TO_LEVEL_UP;
        level += 1;
        experienceBar.SetLevelText(level);
    }

    public void ShuffleUpgrades()
    {
        for (int i = upgrades.Count -1; i>0; i--)
        {
            int x = Random.Range(0, i + 1);
            UpgradeData shuffleElement = upgrades[i];
            upgrades[i] = upgrades[x];
            upgrades[x] = shuffleElement;
        }
    }

    public List<UpgradeData> GetUpgrades(int count)
    {
        ShuffleUpgrades();
        List<UpgradeData> upgradeList = new List<UpgradeData>();

        if (count > upgrades.Count)
        {
            count = upgrades.Count;
        }

        for (int i = 0; i < count; i++)
        {
            upgradeList.Add(upgrades[i]);
        }
        
        return upgradeList;
    }

    public void Upgrade(int selectedUpgradeID)
    {
       UpgradeData upgradeData = selectedUpgrades[selectedUpgradeID];

       if (acquiredUpgarades == null) {acquiredUpgarades = new List<UpgradeData>();}

        switch (upgradeData.upgradeType)
        {
            case UpgradeType.WeaponUpgrade:
                weaponManager.UpgradeWeapon(upgradeData);
                break;
            case UpgradeType.ItemUpgrade:
                passiveItems.UpgradeItem(upgradeData);
                break;
            case UpgradeType.WeaponUnlock:
                weaponManager.AddWeapon(upgradeData.weaponData);
                break;
            case UpgradeType.ItemUnlock:
                passiveItems.Equip(upgradeData.item);
                AddUpgradesIntoTheListOfAvalibleUpgrades(upgradeData.item.upgrades);
                break;
        }

       acquiredUpgarades.Add(upgradeData);
       upgrades.Remove(upgradeData);

    }

    internal void AddUpgradesIntoTheListOfAvalibleUpgrades(List<UpgradeData> upgradesToAdd)
    {
        if(upgradesToAdd == null) {return;}
        this.upgrades.AddRange(upgradesToAdd);
    }
}
