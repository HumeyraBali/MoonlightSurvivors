using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaDamageWeapon : WeaponBase
{
    [SerializeField] float attackAreaSize = 3f;
    public override void Attack()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, attackAreaSize);
        ApplyDamage(colliders);
    }

    private void ApplyDamage(Collider2D[] colliders)
    {
        int damage = GetDamage();
        //int damage = weaponStats.damage;
        for (int i = 0; i < colliders.Length; i++)
        {
            IDamageable e = colliders[i].GetComponent<IDamageable>();
            if (e != null)
            {
                PostDamage(damage, colliders[i].transform.position);
                e.TakeDamage(damage);
            }  
        }
    }
}
