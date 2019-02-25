using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranged : Enemy {

    private float healthValue = 5f;
    private float speedValue = 0f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        setStats(healthValue,speedValue);
    }

    // Update is called once per frame
    void Update()
    {
        EnemyRotation();
        EnemyMovement();
    }
}
