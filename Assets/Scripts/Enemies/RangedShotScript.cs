using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedShotScript : MonoBehaviour
{
    private float velX;
    private float velY;
    public float velocity;
    public float range;
    Rigidbody2D rb;
    private Vector3 startingPos;

    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;        
        GetComponent<AudioSource>().Play();
        var playerPosition = GameObject.Find("Player").transform.position;
        Vector3 direction = startingPos - playerPosition;
        var dirLength = direction.magnitude;

        velX = -direction.x * velocity / dirLength;
        velY = -direction.y * velocity / dirLength;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(velX, velY);
        if ((transform.position - startingPos).magnitude > range)
            Destroy(gameObject);
    }

   public void OnTriggerEnter2D(Collider2D collider)
    {
       if (collider.gameObject.name == "Player")
        {
            collider.gameObject.GetComponent<PlayerCollision>().EnemyCollision(collider);
            Destroy(gameObject);
        }
        if (collider.gameObject.tag == "Enemy" || collider.gameObject.tag == "Wall") 
            Destroy(gameObject);
        
    }

}