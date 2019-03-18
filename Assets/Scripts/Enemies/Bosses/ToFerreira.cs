using System.Collections;
using System.Collections.Generic;
using Kryz.CharacterStats;
using UnityEngine;

public class ToFerreira : Enemy
{

    public DialogueManager dm;
    public GameObject projectile;
    private float healthValue = 200f;
    private float speedValue = 10;
    private int shotRange = 55;
    private int exp = 100;

    private float minFireRate = 0.5f;
    private float maxFireRate = 1f;
    private float nextFire = 0;
    private int ammo = 7;
    private float attackSpeed = 1;
    private int movement;
    private float nextMovement;
    private float currentMovementDuration;
    private float minMoveChangeTime = 1;
    private float maxMoveChangeTime = 2;

    // Start is called before the first frame update
    void Start()
    {
        setXP(exp);
        NextShotTime();
        NextMovement();
        player = GameObject.Find("Player");
        boss = "ALGE";
        setStats(healthValue, speedValue);
        anim = GetComponent<Animator>();
        anim.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (dm.dialogueEnd){
            EnemyRotation();
            EnemyMovement();
            anim.enabled = true;


            if (ammo <= 0) {
                nextFire += 4;
                ammo = 7;
            }

            if (health.Value <= healthValue / 2 && attackSpeed == 1) {
                attackSpeed *= 2;
                StatModifier mod = new StatModifier(1, StatModType.PercentAdd);
                speed.AddModifier(mod);
            }

            if (health.Value <= healthValue / 4 && attackSpeed == 2) {
                attackSpeed *= 2;
                StatModifier mod = new StatModifier(1, StatModType.PercentAdd);
                speed.AddModifier(mod);
            }

            if (Time.time >= nextFire) {
                Shoot();
                NextShotTime();
            }
            

            if (Time.time >= nextMovement) {
                if (movement != 0) {
                    NextMovement();
                } else {
                    movement = 1;
                    nextMovement = Time.time + currentMovementDuration;
                }
            }
        }
    }

    private void NextShotTime()
    {
        nextFire = Time.time + Random.Range(minFireRate / attackSpeed, maxFireRate / attackSpeed);
    }

    private void Shoot()
    {
        var projPos = transform.position;
        GameObject basketBall = Instantiate(projectile, projPos, Quaternion.identity);
        basketBall.GetComponent<RangedShotScript>().range = shotRange;

        Physics2D.IgnoreCollision(basketBall.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        ammo--;
    }

    private void NextMovement()
    {
        movement = Random.Range(0, 3);
        currentMovementDuration = Random.Range(minMoveChangeTime, maxMoveChangeTime);
        nextMovement = Time.time + currentMovementDuration;
    }

    private new void EnemyMovement()
    {
        Vector3 moveVec = new Vector3(0f,0f,0f);
        switch(movement) {
            case 0:
                moveVec = new Vector3(0f, 1f, 0f);
                break;
            case 1:
                moveVec = new Vector3(0f, -1f, 0f);
                break;
            case 2:
                moveVec = new Vector3(-1f, 0f, 0f);
                break;
            case 3:
                moveVec = new Vector3(1f, 0f, 0f);
                break;
            default:
                break;
        }
        rb.velocity = new Vector2( moveVec.x * speed.Value, moveVec.y * speed.Value);
    }
}
