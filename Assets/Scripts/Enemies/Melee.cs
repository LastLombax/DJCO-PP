using UnityEngine;

public class Melee : Enemy {

    private float healthValue = 30f;
    private float speedValue = 10;
    private int exp = 15;

    void Start() {
        player = GameObject.Find("Player");
        int mult = player.GetComponent<PlayerStats>().bossesDefeated + 1;
        setStats(healthValue * mult, speedValue);
        setXP(exp);
    }

    void Update() {
        if (!active)
            return;
        EnemyRotation();
        EnemyMovement();
    }

    public void setEXP(int xp)
    {
        exp = xp;
    }
}