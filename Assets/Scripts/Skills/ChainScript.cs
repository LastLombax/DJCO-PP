using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainScript : MonoBehaviour
{
    private GameObject[] enemiesVisited;
    public float velX;
    public float velY;
    public float velocity;
    public float range;
    Rigidbody2D rb;
    private Vector3 startingPos;

    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = transform.position - mousePosition;
        var dirLenght = Mathf.Sqrt(direction.x * direction.x + direction.y * direction.y);

        velX = -direction.x * (velocity / dirLenght);
        velY = -direction.y * (velocity / dirLenght);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(velX, velY);
        
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
            if (Array.Exists(enemiesVisited, elem => elem = go)) {
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
