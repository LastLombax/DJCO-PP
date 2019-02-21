using UnityEngine;

public class PlayerMobility : MonoBehaviour
{
    public float speed;
    public Animator anim;

    void Update()
    {
        PlayerRotation();
        PlayerMovement();
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
}
