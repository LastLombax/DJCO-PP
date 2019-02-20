using UnityEngine;

public class PlayerMobility : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;

    void Update()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Quaternion rot = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);

        transform.rotation = rot;

        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
        //rb.angularVelocity = 0;

        float moveHorizontal = Input.GetAxis("Horizontal");

        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0);

        transform.position = transform.position + movement* speed;
    }
}
