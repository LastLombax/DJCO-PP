using UnityEngine;

public class Melee : Enemy {

    private float healthValue = 5f;
    private float speedValue = 0.05f;


    void Start() {
        player = GameObject.Find("Player");
        setStats(healthValue,speedValue);
    }

    void Update() {
        EnemyRotation();
        EnemyMovement();
    }

    void EnemyMovement() {
        Vector3 movement = player.transform.position - transform.position;
        transform.position += movement.normalized * speed.Value;
    }

}