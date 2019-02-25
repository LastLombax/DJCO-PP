using System;
using UnityEngine;


public class PlayerCollision : MonoBehaviour
{
    public GameObject map;
    public GameObject skillTree;

    public float impact = 1.2f;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
            EnemyCollision(collision);

        if (collision.gameObject.name == "PC")
            map.GetComponent<MapScript>().ShowMap();

        if (collision.gameObject.name == "DonaLina")
            skillTree.GetComponent<SkillTreeScript>().ShowTree();

        if (collision.gameObject.tag == "ProjectilePlayer")
        {
            Debug.Log("here");
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<CircleCollider2D>(), GetComponent<Collider2D>());
        }
    }

    private void EnemyCollision(Collision2D collision)
    {
        GetComponent<PlayerStats>().EnemyCollision();
        Vector3 force = transform.position - collision.transform.position;
        transform.position = transform.position + force * impact;
    }
}
