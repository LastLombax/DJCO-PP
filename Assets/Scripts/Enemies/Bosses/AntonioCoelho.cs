using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntonioCoelho : Enemy
{

    public GameObject projectileOpen;
    public GameObject projectileCLose;
    private float healthValue = 50f;
    private float speedValue = 0.1f;

    private float minFireRate = 0.3f;
    private float maxFireRate = 0.7f;
    private float nextFire = 0;
    private int ammo = 15;
    private float attackSpeed = 1;

    private bool phase = false;

    // Start is called before the first frame update
    void Start()
    {
        nextShotTime();
        player = GameObject.Find("Player");
        setStats(healthValue, speedValue);
    }

    // Update is called once per frame
    void Update()
    {
        EnemyRotation();
        EnemyMovement();

        if (ammo <= 0)
            phase = !phase;

        if (health.Value <= healthValue / 2 && attackSpeed == 1)
            attackSpeed *= 2;

        if (health.Value <= healthValue / 4 && attackSpeed == 2)
            attackSpeed *= 2;

        if (Time.time > nextFire) {
           // nextShotTime
            shoot();
        }
    }

    private void nextShotTime()
    {
        nextFire = Time.time + Random.Range(minFireRate / attackSpeed, maxFireRate / attackSpeed);
    }

    private void shoot()
    {
        var projPos = transform.position;
        GameObject shot = null;
        if (phase)
            shot = Instantiate(projectileCLose, projPos, Quaternion.identity);
        else
            shot = Instantiate(projectileOpen, projPos, Quaternion.identity);
        Physics2D.IgnoreCollision(shot.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        ammo--;
    }
}
