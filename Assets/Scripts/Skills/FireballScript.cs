using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballScript : Skill
{
    public float velocity;
    protected float range;
    protected float damage;
    protected int projectilesNumber;

    // Start is called before the first frame update
    void Start()
    {
        Setup();
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = transform.position - mousePosition;
        var dirLenght = Mathf.Sqrt(direction.x * direction.x + direction.y * direction.y);

        velX = -direction.x * (velocity / dirLenght);
        velY = -direction.y * (velocity / dirLenght);

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

    public void GiveStats(float rangeStat, float damageStat, int projectileNumberStat)
    {
        range = rangeStat;
        damage = damageStat;
        projectilesNumber = projectileNumberStat;
    }

}
