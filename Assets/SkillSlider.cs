using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSlider : MonoBehaviour
{
    public string skill;
    private GameObject player;
    private float initialWidth;
    private Vector3 localScale;
    private float scaleX;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        GetComponent<SpriteRenderer>().color = Color.green;
        initialWidth = GetComponent<SpriteRenderer>().bounds.size.x;
        localScale = transform.localScale;
        scaleX = localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        float cdPercentage = 0;
        float xPos = 0;
        if (skill.Equals("fireball"))
        {
            cdPercentage = player.GetComponent<PlayerSkills>().GetFireBallCooldownPercentage();
            xPos = GameObject.Find("fireBallBackGround").GetComponent<SkillBarScript>().GetXPosition() + (0.504f * 3);
        } else if (skill.Equals("chain"))
        {
            cdPercentage = player.GetComponent<PlayerSkills>().GetChainCooldownPercentage();
            xPos = GameObject.Find("chainBackGround").GetComponent<SkillBarScript>().GetXPosition() + (0.504f * 3);
        } else if (skill.Equals("poison"))
        {
            cdPercentage = player.GetComponent<PlayerSkills>().GetPoisonCooldownPercentage();
            xPos = GameObject.Find("poisonBackGround").GetComponent<SkillBarScript>().GetXPosition() + (0.504f * 3);
        }
        transform.position = new Vector3(xPos - (1 - cdPercentage) * initialWidth / 2, transform.position.y, transform.position.z);
        localScale.x = cdPercentage * scaleX;
        transform.localScale = localScale;
        if(cdPercentage == 1)
        {
            GetComponent<SpriteRenderer>().color = Color.green;
        } else
        {
            GetComponent<SpriteRenderer>().color = Color.yellow;
        }
    }
}
