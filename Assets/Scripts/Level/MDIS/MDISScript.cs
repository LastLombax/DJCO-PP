using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MDISScript : MonoBehaviour, LevelScript
{
    private GameObject mainCamera, player, chair;
    private int currentRoom;
    public GameObject[] rooms;


    private Vector3 playerNewPos;
    
    private int roomChangeOffset = 5;

    void Start()
    {
        mainCamera = GameObject.Find("Main Camera"); 
        player = GameObject.Find("Player");
        currentRoom = 0;
        rooms[currentRoom].SetActive(true);
        for (int i = 1; i < rooms.Length; i++)
            rooms[i].SetActive(false);
    }

    public void ChangeRoom(int doorID){
        rooms[currentRoom].SetActive(false);


        switch(doorID){
            case 1:
                switch(currentRoom){
                    case 0:
                        mainCamera.transform.position+=new Vector3(-40.4f,-32, 0); //Room 2
                        currentRoom++;
                        playerNewPos = new Vector3(-roomChangeOffset, 0, 0);
                    break;
                    case 1:
                        mainCamera.transform.position+=new Vector3(40.4f, 32, 0); //Room 1
                        currentRoom --;
                        playerNewPos = new Vector3(roomChangeOffset, 0, 0);
                    break;                   
            }
            break;
            case 2:
                switch(currentRoom){
                    case 1:
                        mainCamera.transform.position+=new Vector3(0f, -39, 0); //Room 1
                        currentRoom++;
                        playerNewPos = new Vector3(0, -roomChangeOffset, 0);
                    break;
                    case 2:
                        mainCamera.transform.position+=new Vector3(0f, 39, 0); //Room 1
                        currentRoom --;
                        playerNewPos = new Vector3(0, roomChangeOffset, 0);
                    break;                   
                }
            break;       
        } 
       player.transform.position += playerNewPos;
       rooms[currentRoom].SetActive(true);

    }
}
