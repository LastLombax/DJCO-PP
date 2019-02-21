using UnityEngine;


public class PlayerCollision : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Collision!!!");
            GetComponent<PlayerStats>().EnemyCollision();
        }
    }
}
