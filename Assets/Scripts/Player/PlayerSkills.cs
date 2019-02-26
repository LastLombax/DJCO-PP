using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkills : MonoBehaviour
{
    public GameObject projectileFireBall;
    public GameObject chainProjectile;
    public float weaponDistance = 1.5f;
    public GameObject weapon;
    Vector2 projectilePos;
    public float fireRateFireBall = 0.05f;
    float nextFireFireBall = 0;
    public float fireRateChain = 0.05f;
    float nextFireChain = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && Time.time > nextFireFireBall)
        {
            nextFireFireBall = Time.time + fireRateFireBall;
            Fireball();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && Time.time > nextFireChain)
        {
            nextFireChain = Time.time + fireRateChain;
            ChainLightning();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && Time.time > nextFireFireBall)
        {
            nextFireFireBall = Time.time + fireRateFireBall;
            Fireball();
        }

        if (Input.GetMouseButtonDown(0) && GameObject.Find("Weapon(Clone)") == null) {
            Attack();
        }

    }

    private void Fireball()
    {
        projectilePos = transform.position;
        GameObject fireBall = Instantiate(projectileFireBall, projectilePos, Quaternion.identity);

        Physics2D.IgnoreCollision(fireBall.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    private void ChainLightning()
    {
        projectilePos = transform.position;
        GameObject chainLightning = Instantiate(chainProjectile, projectilePos, Quaternion.identity);

        Physics2D.IgnoreCollision(chainLightning.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    private void Attack()
    {

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePosition - transform.position;

        direction = new Vector3(direction.x, direction.y, 0);

        Vector3 dirLength = direction.normalized;
     
        Vector3 weaponPos = transform.position + dirLength*weaponDistance;

        var attack = Instantiate(weapon, weaponPos, Quaternion.identity);

        Physics2D.IgnoreCollision(attack.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
}
