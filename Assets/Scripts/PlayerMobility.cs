using UnityEngine;

public class PlayerMobility : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;

    // Update is called once per frame
    void FixedUpdate()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Quaternion rot = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);

        transform.rotation = rot;

        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
        //rb.angularVelocity = 0;

        float moveHorizontal = Input.GetAxis("Horizontal");

        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        rb.AddForce(movement * speed); //TODO: ver Time.deltaTime
    }
}
