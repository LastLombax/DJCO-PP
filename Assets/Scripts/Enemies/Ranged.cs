﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Ranged : Enemy {

    public GameObject projectile;
    private float healthValue = 60f;
    private float speedValue = 0f;
    private int exp = 20;

    private float nextFire = 0;
    private float fireRate = 2;

    // Start is called before the first frame update
    void Start()
    {
        nextFire = Time.time + fireRate;
        player = GameObject.Find("Player");
        setStats(healthValue, speedValue);
        setXP(exp);        
    }

    // Update is called once per frame
    void Update()
    {
        if (!active)
            return;
        EnemyRotation();
        EnemyMovement();
        if (Time.time > nextFire) {
            nextFire = Time.time + fireRate;
            shoot();
        }
    }

    private void shoot()
    {
        var projectilePos = transform.position;
        var shot = Instantiate(projectile, projectilePos, Quaternion.identity);
        shot.transform.parent = this.transform;
        Physics2D.IgnoreCollision(shot.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
}
