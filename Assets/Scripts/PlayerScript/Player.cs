using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D RB;
    Animator Anim;
    SpriteRenderer SR;
    private bool IsPlayingWalk;
    public AudioClip walk;
    private AudioSource aud;
    public float MoveSpeed;
    private float Hmove, Vmove;

    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        SR = GetComponent<SpriteRenderer>();
        MoveSpeed = 6;
        IsPlayingWalk = false;
    }

    void Update()
    {
        //Player Movement
        Hmove = Input.GetAxisRaw("Horizontal");
        Vmove = Input.GetAxisRaw("Vertical");
        RB.velocity = new Vector2(Hmove * MoveSpeed, Vmove * MoveSpeed);

        //Updates Animator Component Variables
        Anim.SetFloat("MoveVAxis", RB.velocity.y);
        Anim.SetFloat("MoveXAxis", RB.velocity.x);
        
        //Play sound when walking
        if(!IsPlayingWalk && (RB.velocity.x !=0 || RB.velocity.y != 0)) playsound(walk);
        else if (RB.velocity.x == 0 && RB.velocity.y == 0) stopsound();

        //Flips sprite animation when moving the opposite way.
        if(RB.velocity.x>0) SR.flipX = true;
        else if(RB.velocity.x<0) SR.flipX = false;
        else if(RB.velocity.y>0 && RB.velocity.x == 0 || RB.velocity.y<0 && RB.velocity.x == 0) SR.flipX = false;
    }

    private void playsound(AudioClip e){
        aud = gameObject.AddComponent<AudioSource>();
        aud.clip = e;
        aud.Play();
        aud.loop = true;
        IsPlayingWalk = true;
    }

    private void stopsound(){
        Destroy(aud);
        IsPlayingWalk = false;
    }

}
