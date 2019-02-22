using UnityEngine;


public class PlayerCollision : MonoBehaviour
{
    public float impact = 1.2f;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            GetComponent<PlayerStats>().EnemyCollision();
            Vector3 force = transform.position - collision.transform.position;
            transform.position = transform.position + force * impact;
        }
    }
}
