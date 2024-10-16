using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHp = 1000;
    public int currentHp = 1000;
    public int armor = 0;
    bool isDead = false;

    [SerializeField] StatusBar hpBar;

    [HideInInspector] public Level level;
    [HideInInspector] public Coin coins;

    private void Awake() 
    {
        level = GetComponent<Level>();
        coins = GetComponent<Coin>();
    }

    private void Start() 
    {
        hpBar.SetState(currentHp, maxHp);
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
