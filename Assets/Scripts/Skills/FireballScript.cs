using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballScript : Skill
{
    public float velocity;
    protected float range;
    protected float damage;
    protected int projectilesNumber;
    private int projNumber;

    // Start is called before the first frame update
    void Start()
    {
        Setup();
        

    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(velX, velY);
        Vector3 direction = transform.position - startingPos;
        if (Mathf.Sqrt(Mathf.Pow(direction.x, 2) + Mathf.Pow(direction.y, 2)) > range)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().DmgCollision(damage * -1);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Wall") 
            Destroy(gameObject);
    }

    public void GiveStats(float rangeStat, float damageStat, int projectileNumberStat, int projectileNumber)
    {
        range = rangeStat;
        damage = damageStat;
        projectilesNumber = projectileNumberStat;
        projNumber = projectileNumber;

        float ang = -Mathf.PI/12 * (projectilesNumber - 1) + (Mathf.PI/6 * projNumber);

        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = transform.position - mousePosition;
        float realAng = Mathf.Atan2(direction.y, direction.x) + ang;

        velX = -Mathf.Cos(realAng) * velocity;
        velY = -Mathf.Sin(realAng) * velocity;
    }

}
