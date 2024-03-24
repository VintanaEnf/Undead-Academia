using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //Call components.
    Rigidbody2D RB;
    Animator Anim;
    SpriteRenderer SR;

    //Public
    public AudioClip walk;
    public float MoveSpeed;

    //Private
    private float Hmove, Vmove;
    private bool IsPlayingWalk;
    private AudioSource aud;

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
        Vector2 NormalizedMove = new Vector2(Hmove, Vmove).normalized; //Normalizes Vector before multiplication.
        RB.velocity = NormalizedMove*MoveSpeed;

        //Updates Animator Component Variables
        Anim.SetFloat("VAxis", RB.velocity.y);
        Anim.SetFloat("HAxis", RB.velocity.x);
        
        //Play sound when walking
        if(!IsPlayingWalk && (RB.velocity.x !=0 || RB.velocity.y != 0)) playsound(walk);
        else if (RB.velocity.x == 0 && RB.velocity.y == 0) stopsound();

        //Flips sprite animation when moving the opposite way.
        if(RB.velocity.x<0) SR.flipX = true;
        else if(RB.velocity.x>0) SR.flipX = false;
        else if(RB.velocity.y>0 && RB.velocity.x == 0 || RB.velocity.y<0 && RB.velocity.x == 0) SR.flipX = false;
    }

    private void playsound(AudioClip e){
        //This function creates a new audiosource whenever the player is walking.
        //Will play the public audioclip file.
        //will only play a sound when IsPlayingWalk=false
        aud = gameObject.AddComponent<AudioSource>();
        aud.clip = e;
        aud.Play();
        aud.loop = true;
        IsPlayingWalk = true;
    }

    private void stopsound(){
        //destroy audiosource when the player is not walking anymore.
        Destroy(aud);
        IsPlayingWalk = false;
    }

}
