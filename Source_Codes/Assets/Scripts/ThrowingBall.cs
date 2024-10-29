using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingBall : WeaponBase
{
    float balldirection;
    PlayerMovement playerMovement;
    [SerializeField] GameObject ballPrefab;
    [SerializeField] float spread = 0.5f;


    private void Awake() 
    {
        playerMovement = GetComponentInParent<PlayerMovement>();

    }

    public override void Attack()
    {
        for (int i = 0; i < weaponStats.numberOfAttack; i++)
        {
            GameObject thrownBall = Instantiate(ballPrefab);

            Vector3 newposition = transform.position;
            if (weaponStats.numberOfAttack > 1)
            {
                newposition.y -= (spread * (weaponStats.numberOfAttack-1)) / 2;
                newposition.y += i * spread;
            }
            thrownBall.transform.position = newposition;

            balldirection = playerMovement.lastHorizontalVector;
            if (balldirection > 0f) balldirection = 1f;
            else balldirection = -1f;
            //thrownBall.GetComponent<ThrowingBallProjectile>().SetDirection(balldirection,0f);

            ThrowingBallProjectile throwingBallProjectile = thrownBall.GetComponent<ThrowingBallProjectile>();
            throwingBallProjectile.SetDirection(balldirection,0f);
            //throwingBallProjectile.damage = weaponStats.damage;
            throwingBallProjectile.damage = GetDamage();
        }
        
    }
}
