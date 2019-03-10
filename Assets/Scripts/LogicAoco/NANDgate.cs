using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NANDgate : LogicGate
{
    public override bool Output(bool a, bool b)
    {
        return !(a && b);
    }
}
