using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonPuddleScript : MonoBehaviour
{
    private float startTime;
    private float cooldown = 2;
    private float damageCooldown = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - startTime > cooldown)
        {
            Destroy(gameObject);
        }
    }
}
