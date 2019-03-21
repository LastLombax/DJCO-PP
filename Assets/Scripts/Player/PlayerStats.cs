using System.Collections;
using System.Collections.Generic;
using Kryz.CharacterStats;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{

    private GameObject healthBar;
    private GameObject healthBarBackGround;
    public CharacterStat health;
    public CharacterStat energy;
    public CharacterStat speed;
    private float invulnerabilityTime = 1;
    private float nextTimeCanGetDamage;
    private Color invulnerabilityColor;
    private Color vulnerabilityColor;
    private bool dmgTakenFlag;

    public int bossesDefeated = 0;
    public ArrayList ucsCompleted = new ArrayList();

    public void Start()
    {
        nextTimeCanGetDamage = 0;
        invulnerabilityColor = new Color(0.8627f, 0.8627f, 0);
        vulnerabilityColor = new Color(0.784f, 0.078f, 0.078f);
        dmgTakenFlag = false;
    }

    void Update()
    {
        if (nextTimeCanGetDamage > Time.time)
        {
            return;
        }
        if(dmgTakenFlag)
        {
            GameObject.Find("healthBackGround").GetComponent<SpriteRenderer>().color = vulnerabilityColor;
            dmgTakenFlag = false;
        }
        
    }

    public void DmgCollision(float damage)
    {
        if(nextTimeCanGetDamage > Time.time)
        {
            return;
        }
        nextTimeCanGetDamage = Time.time + invulnerabilityTime;
        dmgTakenFlag = true;
        GameObject.Find("healthBackGround").GetComponent<SpriteRenderer>().color = invulnerabilityColor;
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
