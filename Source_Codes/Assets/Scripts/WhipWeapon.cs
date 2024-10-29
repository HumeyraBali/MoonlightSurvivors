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

    public override void Attack()
    {
        StartCoroutine(AttackProcess());
    }

    IEnumerator AttackProcess()
    {
        for (int i = 0; i < weaponStats.numberOfAttack; i++)
        {
            if (playerMovement.lastHorizontalVector > 0)
            {
                rightWhipObject.SetActive(true);
                leftWhipObject.SetActive(false);
                Collider2D[] rightColliders = Physics2D.OverlapBoxAll(rightWhipObject.transform.position,whipAttackSize,0f);
                ApplyDamage(rightColliders);
            }
                
            else
            {
                leftWhipObject.SetActive(true);
                rightWhipObject.SetActive(false);
                Collider2D[] leftColliders = Physics2D.OverlapBoxAll(leftWhipObject.transform.position,whipAttackSize,0f);
                ApplyDamage(leftColliders);
            }
            yield return new WaitForSeconds(0.3f);
        }   
        
    }
}
