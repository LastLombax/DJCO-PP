using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonBottleScript : Skill
{
    public float velocity;
    public float range;
    public GameObject poisonPuddle;
    private float stopLenght;

    // Start is called before the first frame update
    void Start()
    {
        Setup();
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = transform.position - mousePosition;
        stopLenght = Mathf.Sqrt(direction.x * direction.x + direction.y * direction.y);
        if (stopLenght > range)
        {
            stopLenght = range;
        }
        velX = -direction.x * (velocity / stopLenght);
        velY = -direction.y * (velocity / stopLenght);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(velX, velY);
        if ((transform.position - startingPos).magnitude > stopLenght)
        {
            var projectilePos = transform.position;
            GameObject poisonBottle = Instantiate(poisonPuddle, projectilePos, Quaternion.identity);
            Destroy(gameObject);
        }
    }


}