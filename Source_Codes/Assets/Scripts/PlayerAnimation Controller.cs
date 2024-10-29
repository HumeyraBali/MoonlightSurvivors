using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    PlayerMovement playerMovement;
    public SpriteRenderer spriteRenderer;
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    
    void Update()
    {
        if (playerMovement.movement.x == 0f) 
        {
            if (playerMovement.lastHorizontalVector < 0)
            {
                spriteRenderer.flipX = true; 
            }
            else if (playerMovement.lastHorizontalVector > 0)
            {
                spriteRenderer.flipX = false; 
            }
        }
    }
}
