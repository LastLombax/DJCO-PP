using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kryz.CharacterStats;

public class PlayerSkills : MonoBehaviour
{
    public GameObject fireBallProjectile;
    public GameObject chainProjectile;
    public GameObject poisonProjectile;
    public float weaponDistance = 1.5f;
    public GameObject weapon;
    public float nextFireFireBall = 0;
    public float nextFireChain = 0;
    public float nextFirePoison = 0;

    private int xp;

    protected CharacterStat fireBallRange;
    protected CharacterStat fireBallCooldown;
    protected CharacterStat fireBallDamage;
    protected CharacterStat fireBallProjectilesNumber;
    protected CharacterStat chainRange;
    protected CharacterStat chainCooldown;
    protected CharacterStat chainDamage;
    protected CharacterStat chainNumberBounces;
    protected CharacterStat poisonRange;
    protected CharacterStat poisonCooldown;
    protected CharacterStat poisonDamage;
    protected CharacterStat poisonTime;

    private Dictionary<string, SkillTreeNode> fireBallNodes;
    private Dictionary<string, SkillTreeNode> chainNodes;
    private Dictionary<string, SkillTreeNode> poisonNodes;

    // Start is called before the first frame update


    public static PlayerSkills Instance;

    void Awake()
    {
        if(Instance){
            Destroy(gameObject);
        }else
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        xp = 100;
        fireBallRange = new CharacterStat(30); //initial range = 15
        fireBallCooldown = new CharacterStat(2); //initial cooldown = 2 seconds
        fireBallDamage = new CharacterStat(20); //inital damage of 20
        fireBallProjectilesNumber = new CharacterStat(1); //only one projectile in the beginning
        chainRange = new CharacterStat(25); //initial range = 25
        chainCooldown = new CharacterStat(2); //initial cooldown = 2 seconds
        chainDamage = new CharacterStat(5); //inital damage of 5
        chainNumberBounces = new CharacterStat(2); //initial 2 bounces
        poisonRange = new CharacterStat(20); //initial range = 20
        poisonCooldown = new CharacterStat(2); //initial cooldown = 2 seconds
        poisonDamage = new CharacterStat(5); //inital damage of 5
        poisonTime = new CharacterStat(2); //initial time = 2 seconds
        fireBallNodes = new Dictionary<string, SkillTreeNode>();
        chainNodes = new Dictionary<string, SkillTreeNode>();
        poisonNodes = new Dictionary<string, SkillTreeNode>();
    }

// Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && Time.time > nextFireFireBall)
        {
            nextFireFireBall = Time.time + fireBallCooldown.Value;
            Fireball();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && Time.time > nextFireChain)
        {
            nextFireChain = Time.time + chainCooldown.Value;
            ChainLightning();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && Time.time > nextFirePoison)
        {
            nextFirePoison = Time.time + poisonCooldown.Value;
            PoisonBottle();
        }

        if (Input.GetMouseButtonDown(0) && GameObject.Find("Weapon(Clone)") == null) {
            Attack();
        }

    }

    private void Fireball()
    {
        GameObject fireBall = Instantiate(fireBallProjectile, transform.position, Quaternion.identity);
        fireBall.GetComponent<FireballScript>().GiveStats(fireBallRange.Value, fireBallDamage.Value, (int)fireBallProjectilesNumber.Value);

        Physics2D.IgnoreCollision(fireBall.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    private void ChainLightning()
    {
        GameObject chainLightning = Instantiate(chainProjectile, transform.position, Quaternion.identity);
        chainLightning.GetComponent<ChainScript>().GiveStats(chainRange.Value, chainDamage.Value, (int)chainNumberBounces.Value);
    }

    private void PoisonBottle()
    {
        GameObject poisonBottle = Instantiate(poisonProjectile, transform.position, Quaternion.identity);
        poisonBottle.GetComponent<PoisonBottleScript>().GiveStats(poisonRange.Value, poisonDamage.Value, poisonTime.Value);
    }

    private void Attack()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - transform.position;
        Vector3 dirNormalized = direction.normalized;
        float dirX = Mathf.Cos(Mathf.PI / 3 + Mathf.Atan2(dirNormalized.y,dirNormalized.x));
        float dirY = Mathf.Sin(Mathf.PI / 3 + Mathf.Atan2(dirNormalized.y, dirNormalized.x));
        Vector3 directionShifted = new Vector3(dirX, dirY, 0);
     
        Vector3 weaponPos = transform.position + directionShifted * weaponDistance;

        var attack = Instantiate(weapon, weaponPos, Quaternion.identity);

        Physics2D.IgnoreCollision(attack.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    public void UpgradeSkill(int type, float value) //type: (0 - fireBallRange) - (11 -poisonTime) same order above
    {
        StatModifier modifierPerc = new StatModifier(value, StatModType.PercentMult);
        StatModifier modifierPercAdd = new StatModifier(value, StatModType.PercentAdd);
        StatModifier modifierAdd = new StatModifier(value, StatModType.Flat);

        switch (type)
        {
            case 0:
                fireBallRange.AddModifier(modifierAdd);
                break;
            case 1:
                fireBallCooldown.AddModifier(modifierPerc);
                break;
            case 2:
                fireBallDamage.AddModifier(modifierPercAdd);
                break;
            case 3:
                fireBallProjectilesNumber.AddModifier(modifierAdd);
                break;
            case 4:
                chainRange.AddModifier(modifierAdd);
                break;
            case 5:
                chainCooldown.AddModifier(modifierPerc);
                break;
            case 6:
                chainDamage.AddModifier(modifierPercAdd);
                break;
            case 7:
                chainNumberBounces.AddModifier(modifierAdd);
                break;
            case 8:
                poisonRange.AddModifier(modifierAdd);
                break;
            case 9:
                poisonCooldown.AddModifier(modifierPerc);
                break;
            case 10:
                poisonDamage.AddModifier(modifierPercAdd);
                break;
            case 11:
                poisonTime.AddModifier(modifierPercAdd);
                break;
        }
    }

    public bool HasEnoughXP(int xpNeeded)
    {
        return this.xp >= xpNeeded;
    }

    public void UseXP(int xpUsed)
    {
        if(xp < xpUsed)
        {
            Debug.Log("Not enough xp for that, pls check code, test first with HasEnoughXP(int)");
        }
        xp -= xpUsed;
    }

    public void GainXP(int xpGained)
    {
        xp += xpGained;
    }

    public void StoreFireballTree(Dictionary<string, SkillTreeNode> tree)
    {
        fireBallNodes = tree;
        Debug.Log(fireBallNodes);
    }

    public Dictionary<string, SkillTreeNode> GetFireballTree()
    {
        Debug.Log(fireBallNodes);
        return fireBallNodes;
    }

    public void StoreChainTree(Dictionary<string, SkillTreeNode> tree)
    {
        chainNodes = tree;
    }
    public Dictionary<string, SkillTreeNode> GetChainTree()
    {
        return chainNodes;
    }

    public void StorePoisonTree(Dictionary<string, SkillTreeNode> tree)
    {
        poisonNodes = tree;
    }
    public Dictionary<string, SkillTreeNode> GetPoisonTree()
    {
        return poisonNodes;
    }
}
