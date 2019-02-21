using Kryz.CharacterStats;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public CharacterStat health;
    public CharacterStat energy;
    public CharacterStat speed;

    void Start()
    {
        health.BaseValue = 5;
        energy.BaseValue = 5;
        speed.BaseValue = 5;
    }

    // Update is called once per frame
    void Update()
    {
        //StatModifier mod = new StatModifier(10, StatModType.Flat);
        //health.AddModifier(mod);
        //Debug.Log(health.Value);
    }

    public void EnemyCollision()
    {
        StatModifier collisionDmg = new StatModifier(-10, StatModType.Flat);
        health.AddModifier(collisionDmg);
    }
}
