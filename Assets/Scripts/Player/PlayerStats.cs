using System.Collections;
using System.Collections.Generic;
using Kryz.CharacterStats;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{

    private GameObject healthBar;
    public CharacterStat health;
    public CharacterStat energy;
    public CharacterStat speed;

    public int bossesDefeated = 0;
    public ArrayList ucsCompleted = new ArrayList();

    public void Start()
    {
        healthBar = GameObject.Find("HealthBarSlider");
    }

    public void DmgCollision(float damage)
    {
        StatModifier collisionDmg = new StatModifier(damage, StatModType.Flat);
        health.AddModifier(collisionDmg);
        GameObject.Find("healthSlider").GetComponent<HealthBarSlider>().ChangeLife(health.Value / health.BaseValue);
        
        if (health.Value <= 0){
            gameObject.GetComponent<PlayerCollision>().knockBackEnd = 0;
            SceneManager.LoadScene("MainRoom", LoadSceneMode.Single);
            StatModifier healBack = new StatModifier(health.BaseValue, StatModType.Flat);
            health.AddModifier(healBack);
            GameObject.Find("healthSlider").GetComponent<HealthBarSlider>().ChangeLife(health.Value / health.BaseValue);
            // health.RemoveAllModifiersFromSource(health);
        }
    }

    public void CompleteUC(string uc) {
        bossesDefeated++;
        ucsCompleted.Add(uc);
    }
}
