using UnityEngine;

public class PlayerMobility : MonoBehaviour
{
    public float speed;
    public Animator anim;

    public GameObject projectile;
    Vector2 projectilePos;
    public float fireRate = 0.05f;
    float nextFire = 0;

    void Update()
    {
        PlayerRotation();
        PlayerMovement();
        PlayerSkills();
    }

    private void PlayerRotation()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Quaternion rot = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);

        var ang = rot.eulerAngles.z;
        //Debug.Log(rot.eulerAngles.z);
        if ((ang >= 0 && ang <= 45) || (ang <= 360 && ang >= 315))
        {
            anim.Play("PlayerAnimationUp");
        }
        if (ang > 45 && ang < 135)
        {
            anim.Play("PlayerAnimationLeft");
        }
        if (ang > 135 && ang < 225)
        {
            anim.Play("PlayerAnimationDown");
        }
        if (ang > 225 && ang < 315)
        {
            anim.Play("PlayerAnimationRight");
        }
        //transform.rotation = rot;

        //transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
    }

    private void PlayerMovement()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0f);
        transform.position = transform.position + movement * speed;
    }

    private void PlayerSkills()
    {
        if(Input.GetKeyDown(KeyCode.Q) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            fire();
        }
    }

    private void fire()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = transform.position - mousePosition;
        var dirLenght = Mathf.Sqrt(direction.x * direction.x + direction.y * direction.y);
    

        projectilePos = transform.position;
        projectilePos.x -= 2 * (direction.x / dirLenght);
        projectilePos.y -= 2 * (direction.y / dirLenght);
        Instantiate(projectile, projectilePos, Quaternion.identity);
    }

}
