using UnityEngine;

[CreateAssetMenu(menuName = "Skills/ProjectileSkill")]
public class ProjectileSkill : Skill
{
    public float projectileForce = 500f;
    public Rigidbody2D projectile;

    private ProjectileTrigger launcher;

    public override void Initialize(GameObject obj)
    {
        launcher = obj.GetComponent<ProjectileTrigger>();
        launcher.projectileForce = projectileForce;
        //launcher.projectile = projectile;
    }

    public override void TriggerAbility()
    {
        launcher.Launch();
    }

}