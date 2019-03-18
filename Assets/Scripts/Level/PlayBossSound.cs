using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBossSound : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision){
       if (collision.gameObject.name == "Player" && !GetComponent<AudioSource>().isPlaying){
           collision.GetComponent<AudioSource>().Stop();
           GetComponent<AudioSource>().Play();
       }
   }
}
