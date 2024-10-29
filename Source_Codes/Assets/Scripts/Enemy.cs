using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

[Serializable]
public class EnemyStats
{
    public int hp = 999;
    public int damage = 1;
    public int experience_reward = 200;
    public float speed;

    public EnemyStats(EnemyStats stats)
    {
        this.hp = stats.hp;
        this.damage = stats.damage;
        this.experience_reward = stats.experience_reward;
        this.speed = stats.speed;
    }

    internal void ApplyProgress(float progress)
    {
        this.hp = (int)(hp * progress);
        this.damage = (int)(damage * progress);
    }
}

public class Enemy : MonoBehaviour, IDamageable
{
    Transform targetDestination;
    GameObject targetGameobject;
    Player targetPlayer;
    Rigidbody2D rb;
    public EnemyStats stats;
    public Vector3 direction;

    private void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();  
    }

    public void SetTarget(GameObject target)
    {
        targetGameobject = target;
        targetDestination = target.transform;
    }

    public void FixedUpdate() 
    {
        direction = (targetDestination.position - transform.position).normalized;
        rb.velocity = direction * stats.speed;
    }

    private void OnCollisionStay2D(Collision2D collision) 
    {
        if (collision.gameObject == targetGameobject)
        {
            Attack();
        }
    }

    private void Attack()
    {
        if (targetPlayer == null)
            targetPlayer = targetGameobject.GetComponent<Player>();
        
        targetPlayer.TakeDamage(stats.damage);
    }

    public void TakeDamage(int damage)
    {
        stats.hp -= damage;

        if (stats.hp < 1)
        {
            targetGameobject.GetComponent<Level>().AddExperience(stats.experience_reward);
            GetComponent<DropOnDestroy>().CheckDrop();
            Destroy(gameObject);
        }
            
    }

    internal void SetStats(EnemyStats stats)
    {
        this.stats = new EnemyStats(stats);
    }

    internal void UpdateStatsForProgress(float progress)
    {
        stats.ApplyProgress(progress);
    }
}
