using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 5f;
    [HideInInspector]
    public Vector2 movement;
    [HideInInspector]
    public float lastHorizontalVector;
    [HideInInspector]
    public float lastVerticalVector;

    Animate animate;
   
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        movement = new Vector2();
        animate = GetComponent<Animate>();
    }

    private void Start() 
    {
        lastHorizontalVector = -1f;
        lastVerticalVector = 1f;
    }

    
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        if(movement.x != 0f)
            lastHorizontalVector = movement.x;
        if(movement.y != 0f)
            lastVerticalVector = movement.y;

        animate.horizontal = movement.x;

        movement *= speed;
        rb.velocity = movement;
    }
}
