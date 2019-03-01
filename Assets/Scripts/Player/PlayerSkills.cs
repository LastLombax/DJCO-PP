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
    float nextFireFireBall = 0;
    float nextFireChain = 0;
    float nextFirePoison = 0;

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
        fireBallRange = new CharacterStat(15); //initial range = 15
        fireBallCooldown = new CharacterStat(2); //initial cooldown = 2 seconds
        fireBallDamage = new CharacterStat(20); //inital damage of 20
        fireBallProjectilesNumber = new CharacterStat(1); //only one projectile in the beginning
        chainRange = new CharacterStat(15); //initial range = 15
        chainCooldown = new CharacterStat(2); //initial cooldown = 2 seconds
        chainDamage = new CharacterStat(5); //inital damage of 5
        chainNumberBounces = new CharacterStat(2); //initial 2 bounces
        poisonRange = new CharacterStat(15); //initial range = 15
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
    }

    private void Attack()
    {

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePosition - transform.position;
        Vector3 dirNormalized = direction.normalized;
        float dirX = Mathf.Cos(- Mathf.PI / 3 + Mathf.Acos(dirNormalized.x)) * direction.x;
        float dirY = Mathf.Sin(- Mathf.PI / 3 + Mathf.Asin(dirNormalized.y)) * direction.y;
        direction = new Vector3(dirX, dirY, 0);
        Debug.Log(direction);
     
        Vector3 weaponPos = transform.position + dirNormalized * weaponDistance;

        var attack = Instantiate(weapon, weaponPos, Quaternion.identity);

        Physics2D.IgnoreCollision(attack.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
}
