using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    Enemy enemy;
    private SpriteRenderer spriteRenderer;
    private Animator anim;

    private void Awake() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); 
        anim = GetComponent<Animator>();
        enemy = FindObjectOfType<Enemy>();
    }

    private void Update() 
    {
        //Debug.Log(enemy.direction.x);
    }
    
    void FixedUpdate()
    {
        if (enemy.direction.x < 0)
        {
            spriteRenderer.flipX = false; // No flipping
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }
        else if (enemy.direction.x >= 0)
        {
            spriteRenderer.flipX = true; // Flip horizontally
            transform.localScale = new Vector2(-Mathf.Abs(transform.localScale.x), transform.localScale.y);
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y); // Flip localScale.x
        }
    }

}
