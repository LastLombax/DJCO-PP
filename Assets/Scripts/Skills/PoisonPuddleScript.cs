using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonPuddleScript : MonoBehaviour
{
    private Dictionary<GameObject, float> enemiesNextDamageTick;
    private float damage;
    private float startTime;
    private float puddleDuration;
    private float damageCooldown = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().Play();
        enemiesNextDamageTick = new Dictionary<GameObject, float>();
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - startTime > puddleDuration)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if(enemiesNextDamageTick.ContainsKey(collision.gameObject))
            {
                if(Time.time > enemiesNextDamageTick[collision.gameObject])
                {
                    collision.gameObject.GetComponent<Enemy>().DmgCollision(-damage);
                    enemiesNextDamageTick[collision.gameObject] = Time.time + damageCooldown;
                }
            } else
            {
                collision.gameObject.GetComponent<Enemy>().DmgCollision(-damage);
                enemiesNextDamageTick.Add(collision.gameObject, Time.time + damageCooldown);
            }
        }
    }

    public void GiveStats(float damageStat, float puddleDurationStat)
    {
        damage = damageStat;
        puddleDuration = puddleDurationStat;
    }
}
