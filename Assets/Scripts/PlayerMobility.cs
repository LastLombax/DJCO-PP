using System;
using UnityEngine;

public class PlayerMobility : MonoBehaviour
{
    public float speed;

    void Update()
    {
        PlayerRotation();
        PlayerMovement();
    }

    private void PlayerRotation()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Quaternion rot = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);

        transform.rotation = rot;

        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
    }

    private void PlayerMovement()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0f);
        transform.position = transform.position + movement * speed;
    }
}
