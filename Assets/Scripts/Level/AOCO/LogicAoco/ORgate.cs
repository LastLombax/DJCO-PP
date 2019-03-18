using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ORgate : LogicGate
{
    public override bool Output(bool a, bool b)
    {
        return a || b;
    }
}