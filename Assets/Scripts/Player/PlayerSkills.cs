using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkills : MonoBehaviour
{

    public GameObject projectile;
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
    }

    private void fireball()
    {
        projectilePos = transform.position;
        var fireBall = Instantiate(projectile, projectilePos, Quaternion.identity);

        Physics2D.IgnoreCollision(fireBall.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
}
