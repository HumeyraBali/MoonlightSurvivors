using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    public WeaponData weaponData;

    public WeaponStats weaponStats;
    float timer;
    Player wielder;

    public void Update() {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            Attack();
            timer = weaponStats.timeToAttack;
        }
    }

    public virtual void SetData(WeaponData wd)
    {
        weaponData = wd;

        weaponStats = new WeaponStats(wd.stats.damage, wd.stats.timeToAttack, wd.stats.numberOfAttack);
    }

    public abstract void Attack();

    public int GetDamage()
    {
        //int damage = (int)(weaponData.stats.damage * wielder.damageBonus);
        int damage = (int)(weaponStats.damage * wielder.damageBonus);
        return damage;
    }

    public virtual void PostDamage(int damage, Vector3 targetPosition)
    {
        MessageSystem.instance.PostMessage(damage.ToString(), targetPosition);
    }

    public void Upgrade(UpgradeData upgradeData)
    {
        weaponStats.Sum(upgradeData.weaponUpgradeStats);
    }

    public void AddOwnerPlayer(Player player)
    {
        wielder = player;
    }
}
