using System;
using UnityEngine;
using System.Collections;


public class PlayerCollision : MonoBehaviour
{
    public GameObject map;
    public GameObject skillTree;

    public GameObject FEUPLetters;

    private static bool playerExists;

    public float impact = 1.2f;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
            EnemyCollision(collision);

        if (collision.gameObject.name == "PC"){
            FEUPLetters.GetComponent<Animator>().enabled = true;
            FEUPLetters.GetComponent<Animator>().Play("PlayerAnimationRightIdle");		
            StartCoroutine(ShowMap(1));
        }

        if (collision.gameObject.name == "DonaLina")
            skillTree.GetComponent<SkillTreeScript>().ShowTree();
     
    }

    public void EnemyCollision(Collision2D collision)
    {
        GetComponent<PlayerStats>().DmgCollision(-1);
        Vector3 force = transform.position - collision.transform.position;
        transform.position = transform.position + force * impact;
    }

    public void EnemyCollision(Collider2D collision)
    {
        GetComponent<PlayerStats>().DmgCollision(-1);
        Vector3 force = transform.position - collision.transform.position;
        transform.position = transform.position + force * impact;
    }

    private IEnumerator ShowMap(float duration)
    {
        yield return new WaitForSeconds(duration);
        map.GetComponent<MapScript>().ShowMap();
        FEUPLetters.GetComponent<Animator>().enabled = false;
    }

}
