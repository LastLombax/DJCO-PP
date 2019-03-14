using System.Collections;
using System.Collections.Generic;
using Kryz.CharacterStats;
using UnityEngine;

public class AntonioCoelho : Enemy
{
    public DialogueManager dm;

    public GameObject projectile;
    public GameObject projectile2;
    private float healthValue = 200f;
    private float speedValue = 10;

    private float minFireRate = 0.3f;
    private float maxFireRate = 0.7f;
    private float nextFire = 0;
    private int ammo = 15;
    private float attackSpeed = 1;

    private int shotRange = 55;
    private bool phase = false;
    private int movement;
    private float nextMovement;
    private float currentMovementDuration;
    private float minMoveChangeTime = 1;
    private float maxMoveChangeTime = 2;

    // Start is called before the first frame update
    void Start()
    {
        NextShotTime();
        NextMovement();
        player = GameObject.Find("Player");
        setStats(healthValue, speedValue);

    }

    // Update is called once per frame
    void Update()
    {
        if (dm.dialogueEnd){

            EnemyRotation();
            EnemyMovement();

            if (ammo <= 0) {
                phase = !phase;
                nextFire += 5;
                ammo = 15;
            }

            if (health.Value <= healthValue / 2 && attackSpeed == 1) {
                Debug.Log("Half HP");
                attackSpeed *= 2;
                StatModifier mod = new StatModifier(1, StatModType.PercentAdd);
                speed.AddModifier(mod);
            }

            if (health.Value <= healthValue / 4 && attackSpeed == 2) {
                Debug.Log("Quarter HP");
                attackSpeed *= 2;
                StatModifier mod = new StatModifier(1, StatModType.PercentAdd);
                speed.AddModifier(mod);
            }

            if (Time.time >= nextFire) {
                Shoot();
                NextShotTime();
            }
            

            if (Time.time >= nextMovement) {
                if (movement != 2) {
                    NextMovement();
                } else {
                    movement = 3;
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
        GameObject parenthesis = null;
        if (phase){
            parenthesis = Instantiate(projectile2, projPos, Quaternion.identity);
        } else {
            parenthesis = Instantiate(projectile, projPos, Quaternion.identity);
        }
        parenthesis.GetComponent<RangedShotScript>().range = shotRange;
        Physics2D.IgnoreCollision(parenthesis.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        ammo--;
    }

    private void NextMovement()
    {
        movement = Random.Range(0, 3);
        currentMovementDuration = Random.Range(minMoveChangeTime, maxMoveChangeTime);
        nextMovement = Time.time + currentMovementDuration;
    }

    private void EnemyMovement()
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
