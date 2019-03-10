using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LogicGate : MonoBehaviour
{
    private bool grabbed;
    private bool socketed;
    private bool leaveSocket;
    private GameObject timer;
    
    public abstract bool Output(bool a, bool b);
    void Start()
    {
        leaveSocket = false;
        grabbed = false;
        socketed = false;
        timer = GameObject.Find("Timer");
    }

    void Update()
    {
        if (!grabbed || socketed)
        {
            return;
        }
        if(Input.GetMouseButton(0))
        {
            Vector2 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            gameObject.transform.position = newPos;
        } else
        {
            timer.GetComponent<TimerScript>().logicGatePickedUp = false;
            grabbed = false;
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (leaveSocket)
        {
            leaveSocket = false;
            collision.gameObject.GetComponent<SocketScript>().hasGate = false;
        }
        if (socketed)
        {
            
            return;
        }
        if(!collision.gameObject.tag.Equals("Socket"))
        {
            return;
        }
        if(grabbed || collision.gameObject.GetComponent<SocketScript>().hasGate)
        {
            return;
        }
        grabbed = false;
        socketed = true;
        Vector2 newPos = collision.gameObject.transform.position;
        gameObject.transform.position = newPos;
        collision.gameObject.GetComponent<SocketScript>().logicGate = gameObject;
        collision.gameObject.GetComponent<SocketScript>().hasGate = true;
    }
    

    public void OnMouseOver()
    {
        if (timer.GetComponent<TimerScript>().logicGatePickedUp == true)
        {
            return;
        }
        if (Input.GetMouseButton(0))
        {
            if(socketed)
            {
                socketed = false;
                leaveSocket = true;
            }
            timer.GetComponent<TimerScript>().logicGatePickedUp = true;
            grabbed = true;
        } else
        {
            grabbed = false;
        }
    }
}
