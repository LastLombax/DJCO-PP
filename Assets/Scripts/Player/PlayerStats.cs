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
    }

    public void DmgCollision(float damage)
    {
        StatModifier collisionDmg = new StatModifier(damage, StatModType.Flat);
        health.AddModifier(collisionDmg);
        
        if (health.Value <= 0)
            Debug.Log("Game Over");
    }
}
