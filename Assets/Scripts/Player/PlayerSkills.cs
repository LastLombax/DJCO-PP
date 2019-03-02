using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kryz.CharacterStats;

public class PlayerSkills : MonoBehaviour
{
    public GameObject fireBallProjectile;
    public GameObject chainProjectile;
    public GameObject poisonProjectile;
    public float weaponDistance = 1.5f;
    public GameObject weapon;
    public float nextFireFireBall = 0;
    public float nextFireChain = 0;
    public float nextFirePoison = 0;

    protected CharacterStat fireBallRange;
    protected CharacterStat fireBallCooldown;
    protected CharacterStat fireBallDamage;
    protected CharacterStat fireBallProjectilesNumber;
    protected CharacterStat chainRange;
    protected CharacterStat chainCooldown;
    protected CharacterStat chainDamage;
    protected CharacterStat chainNumberBounces;
    protected CharacterStat poisonRange;
    protected CharacterStat poisonCooldown;
    protected CharacterStat poisonDamage;
    protected CharacterStat poisonTime;

    // Start is called before the first frame update
    void Start()
    {
        fireBallRange = new CharacterStat(10); //initial range = 10
        fireBallCooldown = new CharacterStat(2); //initial cooldown = 2 seconds
        fireBallDamage = new CharacterStat(20); //inital damage of 20
        fireBallProjectilesNumber = new CharacterStat(1); //only one projectile in the beginning
        chainRange = new CharacterStat(5); //initial range = 5
        chainCooldown = new CharacterStat(2); //initial cooldown = 2 seconds
        chainDamage = new CharacterStat(5); //inital damage of 5
        chainNumberBounces = new CharacterStat(2); //initial 2 bounces
        poisonRange = new CharacterStat(10); //initial range = 10
        poisonCooldown = new CharacterStat(2); //initial cooldown = 2 seconds
        poisonDamage = new CharacterStat(5); //inital damage of 5
        poisonTime = new CharacterStat(2); //initial time = 2 seconds
    }

// Update is called once per frame
    void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) && Time.time > nextFireFireBall)
            {
                nextFireFireBall = Time.time + fireBallCooldown.Value;
                Fireball();
            }
            if (Input.GetKeyDown(KeyCode.Alpha2) && Time.time > nextFireChain)
            {
                nextFireChain = Time.time + chainCooldown.Value;
                ChainLightning();
            }
            if (Input.GetKeyDown(KeyCode.Alpha3) && Time.time > nextFirePoison)
            {
                nextFirePoison = Time.time + poisonCooldown.Value;
                PoisonBottle();
            }

            if (Input.GetMouseButtonDown(0) && GameObject.Find("Weapon(Clone)") == null) {
                Attack();
            }

        }

    private void Fireball()
    {
        GameObject fireBall = Instantiate(fireBallProjectile, transform.position, Quaternion.identity);
        fireBall.GetComponent<FireballScript>().GiveStats(fireBallRange.Value, fireBallDamage.Value, (int)fireBallProjectilesNumber.Value);

        Physics2D.IgnoreCollision(fireBall.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    private void ChainLightning()
    {
        GameObject chainLightning = Instantiate(chainProjectile, transform.position, Quaternion.identity);
        chainLightning.GetComponent<ChainScript>().GiveStats(chainRange.Value, chainDamage.Value, (int)chainNumberBounces.Value);
    }

    private void PoisonBottle()
    {
        GameObject poisonBottle = Instantiate(poisonProjectile, transform.position, Quaternion.identity);
        poisonBottle.GetComponent<PoisonBottleScript>().GiveStats(poisonRange.Value, poisonDamage.Value, poisonTime.Value);
    }

    private void Attack()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - transform.position;
        Vector3 dirNormalized = direction.normalized;
        float dirX = Mathf.Cos(Mathf.PI / 3 + Mathf.Atan2(dirNormalized.y,dirNormalized.x));
        float dirY = Mathf.Sin(Mathf.PI / 3 + Mathf.Atan2(dirNormalized.y, dirNormalized.x));
        Vector3 directionShifted = new Vector3(dirX, dirY, 0);
        Debug.Log(dirX);
     
        Vector3 weaponPos = transform.position + directionShifted * weaponDistance;

        var attack = Instantiate(weapon, weaponPos, Quaternion.identity);

        Physics2D.IgnoreCollision(attack.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
}
