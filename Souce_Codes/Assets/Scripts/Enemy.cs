using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class Enemy : MonoBehaviour, IDamageable
{
    Transform targetDestination;
    [SerializeField] float speed;
    GameObject targetGameobject;
    Player targetPlayer;

    Rigidbody2D rb;
    [SerializeField] int hp = 999;
    [SerializeField] int damage = 1;
    [SerializeField] int experience_reward = 200;

    private void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    public void SetTarget(GameObject target)
    {
        targetGameobject = target;
        targetDestination = target.transform;
    }

    private void FixedUpdate() 
    {
        Vector2 direction = (targetDestination.position - transform.position).normalized;
        rb.velocity = direction * speed;
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
        
        targetPlayer.TakeDamage(damage);
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;

        if (hp < 1)
        {
            targetGameobject.GetComponent<Level>().AddExperience(experience_reward);
            GetComponent<DropOnDestroy>().CheckDrop();
            Destroy(gameObject);
        }
            
    }
}
