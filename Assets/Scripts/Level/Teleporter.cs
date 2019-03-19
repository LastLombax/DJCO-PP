using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public GameManager gm;
    public void Leave()
    {
        StartCoroutine(gm.Load2Scene("MainRoom"));
    }


}
