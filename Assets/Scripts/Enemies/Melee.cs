using UnityEngine;

public class Melee : Enemy {

    private float healthValue = 2f;
    private float speedValue = 10;
    public int exp = 2;

    void Start() {
        player = GameObject.Find("Player");
        setStats(healthValue,speedValue);
        setXP(exp);
    }

    void Update() {
        if (!active)
            return;
        EnemyRotation();
        EnemyMovement();
    }
}