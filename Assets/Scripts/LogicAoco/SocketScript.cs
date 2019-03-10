using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocketScript : MonoBehaviour
{
    public GameObject inputAwire;
    public GameObject inputBwire;
    public GameObject outputWire;
    public GameObject logicGate;
    public bool hasGate;

    // Start is called before the first frame update
    void Start()
    {
        hasGate = false;
    }

    // Update is called once per frame
    void Update()
    {
        bool signalA = inputAwire.GetComponent<WireScript>().IsActive();
        bool signalB = inputBwire.GetComponent<WireScript>().IsActive();
        bool outputSignal = false;
        if (logicGate != null)
        {
            outputSignal = logicGate.GetComponent<LogicGate>().Output(signalA, signalB);
        }
        if (outputSignal)
        {
            outputWire.GetComponent<WireScript>().Activate();
        }
        else
        {
            outputWire.GetComponent<WireScript>().Deactivate();
        }
    }

    
}
