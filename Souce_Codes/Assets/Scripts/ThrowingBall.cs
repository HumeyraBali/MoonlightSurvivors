using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingBall : WeaponBase
{
    float balldirection;
    PlayerMovement playerMovement;
    [SerializeField] GameObject ballPrefab;


    private void Awake() 
    {
        playerMovement = GetComponentInParent<PlayerMovement>();

    }

    public override void Attack()
    {
        GameObject thrownBall = Instantiate(ballPrefab);
        thrownBall.transform.position = transform.position;
        balldirection = playerMovement.lastHorizontalVector;
        if (balldirection > 0f) balldirection = 1f;
        else balldirection = -1f;
        thrownBall.GetComponent<ThrowingBallProjectile>().SetDirection(balldirection,0f);
    }
}
