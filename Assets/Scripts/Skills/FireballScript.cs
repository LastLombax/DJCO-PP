using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballScript : Skill
{
    public float velX;
    public float velY;
    public float velocity;
    public float range;

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

        if((transform.position - startingPos).magnitude > range)
        {
            Destroy(gameObject);
        }
    }


}
