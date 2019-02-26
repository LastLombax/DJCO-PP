using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainScript : MonoBehaviour
{
    private ArrayList enemiesVisited = new ArrayList();
    public int numberBounces;
    private float velX;
    private float velY;
    public float velocity;
    public float range;
    Rigidbody2D rb;
    private Vector3 startingPos;
    private GameObject nearestEnemy;

    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
        rb = GetComponent<Rigidbody2D>();
        nearestEnemy = GetClosestEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        var enemyPosition = nearestEnemy.transform.position;
        Vector3 movement = - transform.position + enemyPosition;
        transform.position += movement.normalized * velocity;

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (numberBounces == 0)
            {
                Destroy(gameObject);
            } else
            {
                enemiesVisited.Add(nearestEnemy);
                nearestEnemy = GetClosestEnemy();
                if(nearestEnemy == null)
                {
                    Destroy(gameObject);
                }
                numberBounces--;
            }
        }
            

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
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
}
