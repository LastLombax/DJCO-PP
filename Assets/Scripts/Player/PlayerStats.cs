using System.Collections;
using System.Collections.Generic;
using Kryz.CharacterStats;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public CharacterStat health;
    public CharacterStat energy;
    public CharacterStat speed;

    public int bossesDefeated = 0;
    public ArrayList ucsCompleted = new ArrayList();

    public void DmgCollision(float damage)
    {
        StatModifier collisionDmg = new StatModifier(damage, StatModType.Flat);
        health.AddModifier(collisionDmg);
        
        if (health.Value <= 0)
            Debug.Log("Game Over");
    }

    public void CompleteUC(string uc) {
        bossesDefeated++;
        ucsCompleted.Add(uc);
    }
}
