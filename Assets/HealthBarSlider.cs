using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarSlider : MonoBehaviour
{
    private GameObject player;
    private float initialWidth;
    private Vector3 localScale;
    private float scaleX;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        GetComponent<SpriteRenderer>().color = Color.green;
        initialWidth = GetComponent<SpriteRenderer>().bounds.size.x;
        localScale = transform.localScale;
        scaleX = localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ChangeLife(float lifePercentage)
    {
        float xPos = GameObject.Find("healthBackGround").GetComponent<HealthBarScript>().GetXPosition() + (0.562f * 3);
        transform.position = new Vector3(xPos - (1-lifePercentage) * initialWidth / 2, transform.position.y, transform.position.z);
        localScale.x = lifePercentage * scaleX;
        transform.localScale = localScale;
        if(lifePercentage > 0.66f)
        {
            GetComponent<SpriteRenderer>().color = Color.green;
        } else if (lifePercentage > 0.33f)
        {
            GetComponent<SpriteRenderer>().color = Color.yellow;
        } else
        {
            GetComponent<SpriteRenderer>().color = Color.red;
        }
    } 
}
