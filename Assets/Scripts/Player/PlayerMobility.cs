using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMobility : MonoBehaviour
{
    public float speed;
    public Animator anim;
    public bool frozen;
    private Rigidbody2D rb;

    private PlayerSkills ps;

    void Start(){
        ps = GetComponent<PlayerSkills>();
        rb = GetComponent<Rigidbody2D>();
        frozen = false;
    }

    void Update()
    {
        PlayerRotation();
        PlayerMovement();
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name != "MainRoom")
            SceneManager.LoadScene("MainRoom");
        
        if(SceneManager.GetActiveScene().name == "MainRoom")
            ps.enabled = false;
        else
            ps.enabled = true;
    }

    private void PlayerRotation()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Quaternion rot = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);

        var ang = rot.eulerAngles.z;
        if ((ang >= 0 && ang <= 45) || (ang <= 360 && ang >= 315))
        {
            if(rb.velocity == Vector2.zero)                
                anim.Play("PlayerAnimationUpIdle");
            else
                anim.Play("PlayerAnimationUp");
        }
        if (ang > 45 && ang < 135)
        {
            if(rb.velocity == Vector2.zero)                
                anim.Play("PlayerAnimationLeftIdle");
            else
                anim.Play("PlayerAnimationLeft");
        }
        if (ang > 135 && ang < 225)
        {
            if(rb.velocity == Vector2.zero)                
                anim.Play("PlayerAnimationDownIdle");
            else
                anim.Play("PlayerAnimationDown");
        }
        if (ang > 225 && ang < 315)
        {
            if(rb.velocity == Vector2.zero)                
                anim.Play("PlayerAnimationRightIdle");
            else
                anim.Play("PlayerAnimationRight");        
        }
    }

    private void PlayerMovement()
    {
        if (frozen) {
            Debug.Log("Frozen");
            rb.velocity = new Vector2(0,0);
            return;
        }
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(moveHorizontal * speed, moveVertical * speed);
    }
}
