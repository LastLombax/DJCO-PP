using Kryz.CharacterStats;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected GameObject player;
    protected CharacterStat health;
    protected CharacterStat speed;
    protected int xp;
    protected Rigidbody2D rb;

    protected bool active = false;

    protected Animator anim;

    public void setStats(float healthValue, float speedValue){
        rb = GetComponent<Rigidbody2D>();
        health = new CharacterStat(healthValue);
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
            Destroy(gameObject);
        }
            
    }

    public void SetActivation(bool status){
        this.active = status;
    }

    public void setXP(int exp){
        xp = exp;
    }

}
