using System;
using UnityEngine;
using System.Collections;


public class PlayerCollision : MonoBehaviour
{
    public GameObject map;
    public GameObject skillTree;

    public GameObject FEUPLetters;

    private static bool playerExists;

    private float impact = 10000f;

    private Vector3 knockBackDirection;
    private float knockBackDuration = 0.5f;
    private float knockBackEnd = 0;

    void Update()
    {
        if(knockBackEnd > Time.time)
        {
            GetComponent<Rigidbody2D>().AddForce(knockBackDirection * impact * (knockBackEnd - Time.time));
            //transform.position += knockBackDirection * impact * (Time.deltaTime / knockBackDuration);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
            EnemyCollision(collision);

        if (collision.gameObject.name == "PC"){
            FEUPLetters.GetComponent<Animator>().enabled = true;
            FEUPLetters.GetComponent<Animator>().Play("PlayerAnimationRightIdle");		
            StartCoroutine(ShowMap(1));
        }    
    }

    public void EnemyCollision(Collision2D collision)
    {
        GetComponent<PlayerStats>().DmgCollision(-1);
        Vector3 force = transform.position - collision.transform.position;
        knockBackDirection = force;
        knockBackEnd = Time.time + knockBackDuration;
    }

    public void EnemyCollision(Collider2D collision)
    {
        GetComponent<PlayerStats>().DmgCollision(-1);
    }

    private IEnumerator ShowMap(float duration)
    {
        yield return new WaitForSeconds(duration);
        map.GetComponent<MapScript>().ShowMap();
        FEUPLetters.GetComponent<Animator>().enabled = false;
    }

}
