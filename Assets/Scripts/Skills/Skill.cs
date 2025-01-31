﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public AudioClip sound;
    protected Rigidbody2D rb;
    protected Vector3 startingPos;
    protected float velX;
    protected float velY;

    protected void Setup(){
        AudioSource audio = gameObject.AddComponent<AudioSource>();
        audio.clip = sound;
        audio.playOnAwake = false;
        audio.loop = false;
        audio.Play();
        startingPos = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    protected void OnCollisionEnter2D(Collision2D collision){
        Destroy(gameObject);
    }
}
