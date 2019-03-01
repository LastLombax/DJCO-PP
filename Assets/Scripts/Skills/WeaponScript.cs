using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    Rigidbody2D rb;
    public float offsetAng = 60;

    private GameObject player;

    public float rotationSpeed = 3;

    private float startAng, endAng, currentAng;
    private Vector3 previousPlayerPos;

    // Start is called before the first frame update
    void Start()
    {   
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");

        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Quaternion rot = Quaternion.LookRotation(mousePosition - player.transform.position, Vector3.forward);
        previousPlayerPos = player.transform.position;

        var midAng = rot.eulerAngles.z;
        currentAng = startAng = midAng + offsetAng;
        endAng = midAng - offsetAng;

        var rotationVector = transform.rotation.eulerAngles;
        rotationVector.z = (-currentAng + 150)%360;
        transform.rotation = Quaternion.Euler(rotationVector);
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
            var positionDiference = player.transform.position - previousPlayerPos;
            previousPlayerPos = player.transform.position;
            transform.position += positionDiference;
        }
    }
}

