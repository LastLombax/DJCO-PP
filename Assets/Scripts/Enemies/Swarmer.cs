﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swarmer : Enemy
{
    public GameObject spawnedEnemy;

    private float healthValue = 5f;
    private float speedValue = 0f;
    private float nextSpawn = 0;
    private float spawnRate = 3;

    //private int maxChildren = 4;

    void Start() {
        nextSpawn = Time.time + spawnRate;
        player = GameObject.Find("Player");
        setStats(healthValue,speedValue);
    }

    void Update() {
        EnemyRotation();
        EnemyMovement();
        if (Time.time > nextSpawn) {
            nextSpawn = Time.time + spawnRate;
            spawn();
        }
    }

    private void spawn()
    {
        var projectilePos = transform.position;
        var shot = Instantiate(spawnedEnemy, projectilePos, Quaternion.identity);
        shot.transform.parent = this.transform;

        Physics2D.IgnoreCollision(shot.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
}
