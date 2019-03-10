using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireScript : MonoBehaviour
{
    public bool active0;
    public bool active1;
    public bool active2;
    public bool active3;
    public bool isStartingWire;
    private bool active;
    public Sprite wireOff;
    public Sprite wireOn;
    private SpriteRenderer spriteRender;

    // Start is called before the first frame update
    void Start()
    {
        spriteRender = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isStartingWire)
        {
            return;
        }
        int timeInterval = (int)Time.time % 8;
        if(timeInterval < 2)
        {
            active = active0;
        } else if(timeInterval < 4)
        {
            active = active1;
        } else if (timeInterval < 6)
        {
            active = active2;
        } else
        {
            active = active3;
        }
        if (active)
        {
            spriteRender.sprite = wireOn;
        } else
        {
            spriteRender.sprite = wireOff;
        }
        
    }

    public bool IsActive()
    {
        return active;
    }

    public void Activate()
    {
        active = true;
        spriteRender.sprite = wireOn;
    }
    public void Deactivate()
    {
        active = false;
        spriteRender.sprite = wireOff;
    }
}
