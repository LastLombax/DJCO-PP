using Kryz.CharacterStats;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public string boss = "";
    protected GameObject player;
    protected CharacterStat health;
    protected CharacterStat speed;
    protected int xp;
    protected Rigidbody2D rb;

    protected bool active = false;

    protected Animator anim;

    public void setStats(float healthValue, float speedValue){
        rb = GetComponent<Rigidbody2D>();
        int mult = player.GetComponent<PlayerStats>().bossesDefeated + 1;
        health = new CharacterStat(healthValue * mult);
        speed = new CharacterStat(speedValue);
    }

    protected void EnemyRotation() {
        Quaternion rot = Quaternion.LookRotation(transform.position - player.transform.position, Vector3.forward);
        var ang = rot.eulerAngles.z;
        if ((ang >= 0 && ang <= 45) || (ang <= 360 && ang >= 315)) {
            //anim.Play("PlayerAnimationUp");
        }
        if (ang > 45 && ang < 135) {
            //anim.Play("PlayerAnimationLeft");
        }
        if (ang > 135 && ang < 225) {
            //anim.Play("PlayerAnimationDown");
        }
        if (ang > 225 && ang < 315) {
            //anim.Play("PlayerAnimationRight");
        }
    }
    protected void EnemyMovement() {
        Vector3 movement = player.transform.position - transform.position;
        rb.velocity = new Vector2( movement.normalized.x * speed.Value, movement.normalized.y * speed.Value);

    }

    public void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.name == "RangedShot(Clone)")
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
    }

    public void DmgCollision(float damage)
    {
        StatModifier collisionDmg = new StatModifier(damage, StatModType.Flat);
        health.AddModifier(collisionDmg);
        
        if (health.Value <= 0){
            PlayerSkills ps = (PlayerSkills)player.GetComponent(typeof(PlayerSkills));
            ps.GainXP(xp);
            if (boss != ""){
                Debug.Log("Pronto passaste, toma lá os ECTs...");
                player.GetComponent<PlayerStats>().CompleteUC(boss);
                GameObject.Find("GameManager").GetComponent<GameManager>().BossResult("Won");
                if (boss == "ALGE")
                    GameObject.Find("door9").GetComponent<AudioSource>().Stop();
                else if (boss == "FPRO")
                    GameObject.Find("door11").GetComponent<AudioSource>().Stop();

                GameObject.Find("Teleporter").GetComponent<Teleporter>().Leave();
            }
            Destroy(gameObject);
        }
            
    }

    public void SetActivation(bool status){
        this.active = status;
    }

    public void setXP(int exp){
        xp = exp;
    }

    public float getEnemyHealthPercentage()
    {
        return health.Value / health.BaseValue;
    }



}
