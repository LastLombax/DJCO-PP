using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swarmer : Enemy
{
    public GameObject spawnedEnemy;

    private float healthValue = 100f;
    private float speedValue = 0f;
    private int exp = 30;
    private float nextSpawn = 0;
    private float spawnRate = 7;

    //private int maxChildren = 4;

    public Sprite spawnedSprite;

    void Start() {
        nextSpawn = Time.time + spawnRate;
        player = GameObject.Find("Player");
        setStats(healthValue,speedValue);
        setXP(exp);
    }

    void Update() {
        if (!active)
            return;
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
        shot.GetComponent<Melee>().setEXP(0);
        shot.GetComponent<SpriteRenderer>().sprite = spawnedSprite;
        shot.GetComponent<Animator>().enabled = false;
        Destroy(shot.GetComponent<BoxCollider2D>());
        shot.AddComponent<PolygonCollider2D>();

        Physics2D.IgnoreCollision(shot.GetComponent<PolygonCollider2D>(), GetComponent<Collider2D>());
    }
}
