using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    Rigidbody2D rb;
    public float offsetAng = 40;

    private GameObject player;

    public float rotationSpeed = 3;

    private float startAng, endAng, currentAng;

    // Start is called before the first frame update
    void Start()
    {   
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");

        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Quaternion rot = Quaternion.LookRotation(mousePosition - transform.position, Vector3.forward);

        var midAng = rot.eulerAngles.z;
        currentAng = startAng = midAng + offsetAng;
        endAng = midAng - offsetAng;

        transform.eulerAngles = new Vector3(
            0,
            0,
            startAng + 35
        );

    }

    // Update is called once per frame
    void Update()
    {
        if (currentAng <= endAng)
           Destroy(gameObject);   
        else
        {
            transform.RotateAround(player.transform.position, Vector3.back, rotationSpeed);
            currentAng= currentAng - rotationSpeed;
        }
    }
}

