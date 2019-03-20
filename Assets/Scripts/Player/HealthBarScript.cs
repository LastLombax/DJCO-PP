using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 positionCam = Camera.main.ViewportToWorldPoint(new Vector3(0.14f, 0.9f, 0));
        transform.position = new Vector3(positionCam.x, positionCam.y, 10);
        GetComponent<SpriteRenderer>().color = new Color(0.784f, 0.078f, 0.078f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RefreshPosition()
    {
        Vector3 positionCam = Camera.main.ViewportToWorldPoint(new Vector3(0.14f, 0.9f, 0));
        transform.position = new Vector3(positionCam.x, positionCam.y, 10);
    }

    public float GetXPosition()
    {
        return transform.position.x;
    }
}
