using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{

    public GameObject room;
    public GameObject otherDoor;
    private float nextOpen;
    private float timeOut;
    // Start is called before the first frame update
    void Start()
    {
        timeOut = 0.5f;
        nextOpen = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateTimeOut()
    {
        nextOpen = Time.time + timeOut;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.gameObject.tag.Equals("Player"))
        {
            return;
        }
        if (nextOpen > Time.time)
        {
            return;
        }
        nextOpen = Time.time + timeOut;
        otherDoor.GetComponent<TeleportScript>().updateTimeOut();
        collision.gameObject.transform.position = otherDoor.transform.position;
        collision.gameObject.GetComponent<PlayerCollision>().knockBackEnd = 0;
        float camX = otherDoor.GetComponent<TeleportScript>().room.transform.position.x;
        float camY = otherDoor.GetComponent<TeleportScript>().room.transform.position.y;
        Camera.main.transform.position = new Vector3(camX, camY, -10);
    }
}
