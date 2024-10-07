using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipWeapon : WeaponBase
{
    [SerializeField] GameObject leftWhipObject;
    [SerializeField] GameObject rightWhipObject;
    [SerializeField] Vector2 whipAttackSize = new Vector2(4f,2f);
    PlayerMovement playerMovement;

    private void Awake() 
    {
        playerMovement = GetComponentInParent<PlayerMovement>();
    }


    private void ApplyDamage(Collider2D[] colliders)
    {
        for (int i = 0; i < colliders.Length; i++)
        {
            IDamageable e = colliders[i].GetComponent<IDamageable>();
            if (e != null)
            {
                PostDamage(weaponStats.damage, colliders[i].transform.position);
                e.TakeDamage(weaponStats.damage);
            }  
        }
    }

    public override void Attack()
    {
        if (playerMovement.lastHorizontalVector > 0)
        {
            rightWhipObject.SetActive(true);
            Collider2D[] rightColliders = Physics2D.OverlapBoxAll(rightWhipObject.transform.position,whipAttackSize,0f);
            ApplyDamage(rightColliders);
        }
            
        else
            leftWhipObject.SetActive(true);
            Collider2D[] leftColliders = Physics2D.OverlapBoxAll(leftWhipObject.transform.position,whipAttackSize,0f);
            ApplyDamage(leftColliders);
    }
}
