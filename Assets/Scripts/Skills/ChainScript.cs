using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainScript : Skill
{
    private ArrayList enemiesVisited = new ArrayList();
    public float velocity;
    public float range;
    public float damage;
    public int numberBounces;
    private GameObject nearestEnemy;
    private bool returning = false;

    // Start is called before the first frame update
    void Start()
    {
        nearestEnemy = GetClosestEnemy();
        if (nearestEnemy == null)
        {
            GameObject.Find("Player").GetComponent<PlayerSkills>().nextFireChain = 0;
            Destroy(gameObject);
            return;
        }
        Setup();
    }

    // Update is called once per frame
    void Update()
    {
        if (nearestEnemy == null)
        {
            numberBounces = 0;
            returning = true;
            nearestEnemy = GameObject.Find("Player");
        }
        var enemyPosition = nearestEnemy.transform.position;
        Vector3 movement = - transform.position + enemyPosition;
        transform.position += movement.normalized * velocity;
    }
 
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && returning)
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().DmgCollision(damage * -1);
            if (numberBounces == 0)
            {
                returning = true;
                nearestEnemy = GameObject.Find("Player");
            } else
            {
                enemiesVisited.Add(nearestEnemy);
                nearestEnemy = GetClosestEnemy();
                if(nearestEnemy == null)
                {
                    returning = true;
                    nearestEnemy = GameObject.Find("Player");
                }
                numberBounces--;
            }
        }
            

    }

    public void GiveStats(float rangeStat, float damageStat, int numberBouncesStat)
    {
        range = rangeStat;
        damage = damageStat;
        numberBounces = numberBouncesStat;
    }

    GameObject GetClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            if (enemiesVisited.Contains(go))
            {
        
                continue;
            }
            Vector3 diff = go.transform.position - position;
            float curDistance = Mathf.Sqrt(Mathf.Pow(diff.x, 2) + Mathf.Pow(diff.y, 2));
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        if(range < distance)
        {
            return null;
        }
        return closest;
    }
}
