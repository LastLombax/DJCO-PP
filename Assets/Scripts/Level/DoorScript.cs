using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private LevelScript levelDoor;

    public GameObject level;

    public int doorID;

    void Start(){
        if (doorID == 0)
            Debug.Log("DOOR ID IS 0");
        levelDoor = level.GetComponent<LevelScript>();
    }
    void OnTriggerEnter2D(Collider2D collider){
        if (collider.gameObject.name == "Player"){
            levelDoor.ChangeRoom(doorID);
        }
    }

}
