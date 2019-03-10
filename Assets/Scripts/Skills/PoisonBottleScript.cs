using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonBottleScript : Skill
{
    public float velocity;
    public float range;
    public float damage;
    private float stopLength;
    private float puddleDuration;
    public GameObject poisonPuddle;
    

    // Start is called before the first frame update
    void Start()
    {
        Setup();
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = transform.position - mousePosition;
        stopLength = Mathf.Sqrt(direction.x * direction.x + direction.y * direction.y);
        if (stopLength > range)
        {
            stopLength = range;
        }
        velX = -direction.x * (Time.deltaTime * 100 * velocity / stopLength);
        velY = -direction.y * (Time.deltaTime * 100 * velocity / stopLength);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(velX, velY);
        if ((transform.position - startingPos).magnitude > stopLength)
        {
            GameObject poisonPuddleInstantiate = Instantiate(poisonPuddle, transform.position, Quaternion.identity);
            poisonPuddleInstantiate.GetComponent<PoisonPuddleScript>().GiveStats(damage, puddleDuration);
            Destroy(gameObject);
        }
    }

    public void GiveStats(float rangeStat, float damageStat, float puddleDurationStat)
    {
        range = rangeStat;
        damage = damageStat;
        puddleDuration = puddleDurationStat;
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall") 
            Destroy(gameObject);
    }


}