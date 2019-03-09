using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomScript : MonoBehaviour
{
    private float minX = 0, maxX= 0, minY= 0, maxY= 0;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        foreach(Transform child in transform)
        {
            if (child.name == "LeftWall")
                minX = child.transform.position.x+0.5f;
            else if (child.name == "RightWall")
                maxX = child.transform.position.x-0.5f;
            else if (child.name == "DownWall")
                minY = child.transform.position.y+0.5f;
            else if (child.name == "UpWall")
                maxY = child.transform.position.y-0.5f;
        }
        Debug.Log("MinX: " + minX + " ; maxX: " + maxX);
        Debug.Log("MinY: " + minY + " ; maxY: " + maxY);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x < minX){
            player.transform.position = new Vector3(minX, player.transform.position.y, 0);
        }
        else if (player.transform.position.x > maxX){
            player.transform.position = new Vector3(maxX, player.transform.position.y, 0);
        }
         else if (player.transform.position.y < minY){
            player.transform.position = new Vector3(player.transform.position.x, minY, 0);
        }
         else if (player.transform.position.y > maxY){
            player.transform.position = new Vector3(player.transform.position.x, maxY, 0);
        }
        
    }
}
