using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    public Sprite sprite0;
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    public GameObject wireEnd1;
    public GameObject wireEnd2;
    public bool logicGatePickedUp;
    private bool timer0Correct;
    private bool timer1Correct;
    private bool timer2Correct;
    private bool timer3Correct;
    private bool gameWon;

    // Start is called before the first frame update
    void Start()
    {
        logicGatePickedUp = false;
        timer0Correct = false;
        timer1Correct = false;
        timer2Correct = false;
        timer3Correct = false;
        gameWon = false;
    }

    // Update is called once per frame
    void Update()
    {
        int timeInterval = (int)Time.time % 8;
        if (timeInterval < 2)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprite0;
            timer0Correct = !wireEnd1.GetComponent<WireScript>().IsActive() && !wireEnd2.GetComponent<WireScript>().IsActive();
        }
        else if (timeInterval < 4)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprite1;
            timer1Correct = !wireEnd1.GetComponent<WireScript>().IsActive() && wireEnd2.GetComponent<WireScript>().IsActive();
        }
        else if (timeInterval < 6)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprite2;
            timer2Correct = wireEnd1.GetComponent<WireScript>().IsActive() && !wireEnd2.GetComponent<WireScript>().IsActive();
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprite3;
            timer3Correct = wireEnd1.GetComponent<WireScript>().IsActive() && wireEnd2.GetComponent<WireScript>().IsActive();
        }

        if(timer0Correct && timer1Correct && timer2Correct && timer3Correct && !gameWon)
        {
            Debug.Log("You won!!");
            gameWon = true;
        }
    }
}
