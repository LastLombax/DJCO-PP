using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDoorScript : MonoBehaviour
{
    public GameObject wireOff;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(wireOff.GetComponent<WireScript>().IsActive())
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "DoorWallHidden";
        } else
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Walls";
        }
    }
}
