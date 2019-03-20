using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPosition : MonoBehaviour
{
    public float xPos;
    public float yPos;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 positionCam = Camera.main.ViewportToWorldPoint(new Vector3(xPos, yPos, 0));
        transform.position = new Vector3(positionCam.x, positionCam.y, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
