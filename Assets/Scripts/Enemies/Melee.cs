using UnityEngine;

public class Melee : Enemy {

    private float healthValue = 2f;
    private float speedValue = 0.05f;

    void Start() {
        player = GameObject.Find("Player");
        setStats(healthValue,speedValue);
    }

    void Update() {
        EnemyRotation();
        EnemyMovement();
    }
}