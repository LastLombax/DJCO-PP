using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AMATScript : MonoBehaviour, LevelScript
{
    private GameObject mainCamera, player;
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
        switch(doorID){
            case 1:
                switch(currentRoom){
                    case 1:
                        mainCamera.transform.position+=new Vector3(40.5f, 0, 0); //Room 2
                        currentRoom = 2;
                        playerNewPos = new Vector3(roomChangeOffset, 0, 0);
                    break;
                    case 2:
                        mainCamera.transform.position+=new Vector3(-40.5f, 0, 0); //Room 1
                        currentRoom = 1;
                        playerNewPos = new Vector3(-roomChangeOffset, 0, 0);
                    break;                   
            }
            break;
            case 2:
                switch(currentRoom){
                    case 2:
                        mainCamera.transform.position+=new Vector3(0, -40.5f, 0); //Room 3
                        currentRoom = 3;
                        playerNewPos = new Vector3(0, -roomChangeOffset, 0);
                    break;
                    case 3:
                        mainCamera.transform.position+=new Vector3(0, 40.5f, 0); //Room 2
                        currentRoom = 2;
                        playerNewPos = new Vector3(0, roomChangeOffset, 0);
                    break;                   
                }
            break;
          /*   case 3:
                switch(currentRoom){
                    case 1:
                        mainCamera.transform.position+=new Vector3(40.5f, 0, 0); //Room 2
                    break;
                }
            break;*/
        } 
        player.transform.position += playerNewPos;
        //GameObject.Find("Room" + currentRoom).SetActive(true);
    }
}
