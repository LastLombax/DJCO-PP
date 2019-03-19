using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorScript : MonoBehaviour
{
    public GameManager gm;
    public bool isPlayerHere = false;
    private ArrayList enemies;
    // Start is called before the first frame update
    void Start()
    {
        enemies = new ArrayList();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("Enemy")){
            enemies.Add(collision.gameObject);
            if (isPlayerHere){
                collision.gameObject.GetComponent<Enemy>().SetActivation(true);
            }
            return;
        }
        if(collision.gameObject.tag.Equals("Player")){
            foreach(GameObject enemy in enemies){
                if (enemy != null)
                    enemy.GetComponent<Enemy>().SetActivation(true);
            }
            isPlayerHere = true;
        }
    }
    
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("Player")){
            foreach(GameObject enemy in enemies){
                if (enemy != null)
                    enemy.GetComponent<Enemy>().SetActivation(false);
            }
            isPlayerHere = false;
            return;
        }

        if (collision.gameObject.tag.Equals("Enemy") && 
                collision.gameObject.GetComponent<Enemy>().boss != "") {
            Debug.Log("Hello");
            StartCoroutine(gm.Load2Scene("MainRoom"));
        }
    }
}
