using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHp = 1000;
    public int currentHp = 1000;
    public float hpRegenerationRate = 1f;
    public float hpRegenerationTimer;
    public int armor = 0;
    bool isDead = false;
    public float damageBonus;

    [SerializeField] StatusBar hpBar;

    [HideInInspector] public Level level;
    [HideInInspector] public Coin coins;

    [SerializeField] DataContainer dataContainer;

    private void Awake() 
    {
        level = GetComponent<Level>();
        coins = GetComponent<Coin>();
    }

    private void Start() 
    {
        LoadSelectedPlayer(dataContainer.selectedPlayer);

        ApplyPersistantUpgrades();

        hpBar.SetState(currentHp, maxHp);
    }

    private void LoadSelectedPlayer(PlayerData selectedPlayer)
    {
        InitAnimation(selectedPlayer.spritePrefab);
        GetComponent<WeaponManager>().AddWeapon(selectedPlayer.startingWeapon);
    }

    private void InitAnimation(GameObject spritePrefab)
    {
        GameObject animObject = Instantiate(spritePrefab, transform);
        GetComponent<Animate>().SetAnimate(animObject);
    }

    private void ApplyPersistantUpgrades()
    {
        int hpUpgradeLevel = dataContainer.GetUpgradeLevel(PlayerPersistentUprades.Hp);
        maxHp += maxHp / 10 * hpUpgradeLevel;

        int damageUpgradeLevel = dataContainer.GetUpgradeLevel(PlayerPersistentUprades.Damage);
        damageBonus = 1f + 0.1f * damageUpgradeLevel;

    }

    public void Update()
    {
        hpRegenerationTimer += Time.deltaTime * hpRegenerationRate;

        if (hpRegenerationTimer > 1f)
        {
            Heal(1);
            hpRegenerationTimer -= 1f;
        }
    }
    public void TakeDamage(int damage)
    {
        if (isDead == true) { return; }
        ApplyArmor(ref damage);
        
        currentHp -= damage;
        if (currentHp <= 0)
        {
            GetComponent<PlayerGameOver>().GameOver();
            isDead = true;
            
        }

        hpBar.SetState(currentHp,maxHp);
    }

    private void ApplyArmor(ref int damage)
    {
        damage -= armor;
        if (damage <= 0) {damage = 0;}
    }

    public void Heal(int amount)
    {
        if (currentHp <= 0)
            return;

        currentHp += amount;
        if (currentHp > maxHp)
            currentHp = maxHp;

        hpBar.SetState(currentHp, maxHp);
    }
}
