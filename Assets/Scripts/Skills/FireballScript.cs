using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballScript : MonoBehaviour
{
    public float velX;
    public float velY;
    public float velocity;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
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
}
