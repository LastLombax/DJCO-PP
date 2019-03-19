using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    Rigidbody2D rb;
    private float offsetAng = 60;

    private GameObject player;

    private AudioSource audioSource;
    private float rotationSpeed = 360;

    private float startAng, endAng, currentAng;
    private Vector3 previousPlayerPos;
    private float damage = 12;
    private bool isRightDirection = true;

    // Start is called before the first frame update
    void Start()
    {   
        audioSource = GetComponent<AudioSource>();
        audioSource.time = 1.3f;
        audioSource.Play(); 
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Quaternion rot = Quaternion.LookRotation(mousePosition - player.transform.position, Vector3.forward);
        previousPlayerPos = player.transform.position;

        var midAng = rot.eulerAngles.z;
        isRightDirection = midAng <= 180;
        if(isRightDirection)
        {
            currentAng = startAng = midAng + offsetAng;
            endAng = midAng - offsetAng;
        } else
        {
            currentAng = startAng = midAng - offsetAng;
            endAng = midAng + offsetAng;
            GetComponent<SpriteRenderer>().flipX = true;
        }

        var rotationVector = transform.rotation.eulerAngles;
        rotationVector.z = (180 - currentAng)%360;
        transform.rotation = Quaternion.Euler(rotationVector);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentAng <= endAng && isRightDirection)
           Destroy(gameObject);
        if (currentAng >= endAng && !isRightDirection)
        {
            Destroy(gameObject);
        }
        else
        {
            if(isRightDirection)
            {
                transform.RotateAround(player.transform.position, Vector3.back, rotationSpeed * Time.deltaTime);
                currentAng -= rotationSpeed * Time.deltaTime;
            } else
            {
                transform.RotateAround(player.transform.position, Vector3.forward, rotationSpeed * Time.deltaTime);
                currentAng += rotationSpeed * Time.deltaTime;
            }
            
            
            var positionDiference = player.transform.position - previousPlayerPos;
            previousPlayerPos = player.transform.position;
            transform.position += positionDiference;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
            collision.gameObject.GetComponent<Enemy>().DmgCollision(damage * -1);
    }
}

