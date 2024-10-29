using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] Transform weaponObjectsContainer;
    List<WeaponBase> weapons;

    Player player;

    private void Awake() 
    {
        weapons = new List<WeaponBase>();
        player = GetComponent<Player>();
    }

    public void AddWeapon(WeaponData weaponData)
    {
        GameObject weaponGameObject = Instantiate(weaponData.weaponBasePrefab, weaponObjectsContainer);
        WeaponBase weaponBase= weaponGameObject.GetComponent<WeaponBase>();

        weaponBase.SetData(weaponData);
        weapons.Add(weaponBase);
        weaponBase.AddOwnerPlayer(player);

        Level level = GetComponent<Level>();
        if (level != null)
            level.AddUpgradesIntoTheListOfAvalibleUpgrades(weaponData.upgrades);
    }

    internal void UpgradeWeapon(UpgradeData upgradeData)
    {
        WeaponBase weaponToUpgrade = weapons.Find(wd => wd.weaponData == upgradeData.weaponData);
        weaponToUpgrade.Upgrade(upgradeData);
    }
}
