using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody2D rb;
    public float MovementSpeed;
    Animator animator;
    SpriteRenderer sr;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float InputV = Input.GetAxisRaw("Vertical");
        float InputH = Input.GetAxisRaw("Horizontal");

        if (InputH != 0) rb.velocity = new Vector2(InputH * MovementSpeed, 0);
        else if (InputV != 0) rb.velocity = new Vector2(0, InputV * MovementSpeed);
        else rb.velocity = new Vector2(0, 0);

        animator.SetFloat("yVelocity", rb.velocity.y);
        animator.SetFloat("xVelocity", rb.velocity.x);

        if (rb.velocity.x > 0) sr.flipX = true;
        else if (rb.velocity.x <0) sr.flipX = false;
    }
}
