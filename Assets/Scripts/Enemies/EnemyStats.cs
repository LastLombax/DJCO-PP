using Kryz.CharacterStats;
using UnityEngine;

public class EnemyStats : MonoBehaviour {
    public CharacterStat health;
    public CharacterStat speed;

    public GameObject player;
    public string behaviour;

    public Animator anim;

    void Start() {
        //Get random stats
        health.BaseValue = 5;
        speed.BaseValue = 0.05f;

        //Get a random behaviour
        behaviour = "Chaser";
        //shootPlayer();
    }

    void Update() {
        EnemyRotation();
        if (behaviour == "Chaser")
            EnemyMovement();
    }

    void EnemyRotation() {
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

    void EnemyMovement() {
        Vector3 movement = player.transform.position - transform.position;
        transform.position += movement.normalized * speed.Value;
    }

}