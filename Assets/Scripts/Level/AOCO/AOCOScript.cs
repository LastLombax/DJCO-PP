using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOCOScript : MonoBehaviour, LevelScript
{
    private GameObject mainCamera, player, chair;
    private int currentRoom;

    private Vector3 playerNewPos;
    
    private int roomChangeOffset = 5;

    void Start()
    {
        mainCamera = GameObject.Find("Main Camera"); 
        player = GameObject.Find("Player");
        currentRoom = 1;
    }

    public void ChangeRoom(int doorID){
        //GameObject.Find("Room" + currentRoom).SetActive(false);
                Debug.Log("previous room" + currentRoom);

        switch(doorID){
            case 1:
                switch(currentRoom){
                    case 1:
                        mainCamera.transform.position+=new Vector3(40.4f, 32, 0); //Room 2
                        currentRoom++;
                        playerNewPos = new Vector3(roomChangeOffset, 0, 0);
                    break;
                    case 2:
                        mainCamera.transform.position+=new Vector3(-40.4f, -32, 0); //Room 1
                        currentRoom --;
                        playerNewPos = new Vector3(-roomChangeOffset, 0, 0);
                    break;                   
            }
            break;
            case 2:
                switch(currentRoom){
                    case 1:
                        mainCamera.transform.position+=new Vector3(40.4f, -32, 0); //Room 3
                        currentRoom = 4;
                        playerNewPos = new Vector3(roomChangeOffset, 0, 0);
                    break;
                    case 4:
                        mainCamera.transform.position+=new Vector3(-40.4f, 32, 0); //Room 2
                        currentRoom = 1;
                        playerNewPos = new Vector3(-roomChangeOffset, 0, 0);
                    break;                   
                }
            break;
            case 3:
                switch(currentRoom){
                    case 3:
                        mainCamera.transform.position+=new Vector3(40.4f, 32, 0); //Room 3
                        currentRoom++;
                        playerNewPos = new Vector3(roomChangeOffset, 0, 0);
                    break;
                    case 4:
                        mainCamera.transform.position+=new Vector3(-40.4f, -32, 0); //Room 2
                        currentRoom --;
                        playerNewPos = new Vector3(-roomChangeOffset, 0, 0);
                    break;                   
                }
            break;
            case 4:
                switch(currentRoom){
                    case 4:
                        mainCamera.transform.position+=new Vector3(0, -40, 0); //Room 5
                        currentRoom++;
                        playerNewPos = new Vector3(0, -roomChangeOffset, 0);
                    break;
                    case 5:
                        mainCamera.transform.position+=new Vector3(0, 40, 0); //Room 4
                        currentRoom--;
                        playerNewPos = new Vector3(0, roomChangeOffset, 0);
                    break;                   
                }
            break; 
        } 
        player.transform.position += playerNewPos;
        //GameObject.Find("Room" + currentRoom).SetActive(true);
        Debug.Log("new room" + currentRoom);
    }
}
