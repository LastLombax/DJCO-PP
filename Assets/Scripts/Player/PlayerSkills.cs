using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkills : MonoBehaviour
{
    public float weaponDistance = 1.5f;
    public GameObject projectile;
    public GameObject weapon;
    Vector2 projectilePos;
    public float fireRate = 0.05f;
    float nextFire = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            fireball();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            fireball();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            fireball();
        }

        if (Input.GetMouseButtonDown(0) && GameObject.Find("Weapon(Clone)") == null) {
            attack();
        }

    }

    private void fireball()
    {
        projectilePos = transform.position;
        var fireBall = Instantiate(projectile, projectilePos, Quaternion.identity);

        Physics2D.IgnoreCollision(fireBall.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
    private void attack(){
       
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePosition - transform.position;

        direction = new Vector3(direction.x, direction.y, 0);

        var dirLength = direction.normalized;
     
        var weaponPos = transform.position + dirLength*weaponDistance;

        var attack = Instantiate(weapon, weaponPos, Quaternion.identity);

        Physics2D.IgnoreCollision(attack.GetComponent<Collider2D>(), GetComponent<Collider2D>());

    }
}
