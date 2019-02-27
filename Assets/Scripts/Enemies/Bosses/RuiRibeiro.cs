using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuiRibeiro : MonoBehaviour
{
    public float objetive = 100;
    public float bossRate = 10;
    public float playerRate = 5;
    public float bossPeriod = 1;
    private float playerPoints = 0;
    private float bossPoints = 0;
    private float nextActionTime = 0;

    public GameManager gm;
    private bool over = false;
    // Update is called once per frame
    void Update()
    {
        if (!over)
            ManageGame();
        else {
            if (bossPoints >= objetive)
                Debug.Log("Era so fazer as continhas... tás chumbado");
            else if (playerPoints >= objetive)
                Debug.Log("Passaste");
            StartCoroutine(gm.Load2Scene("MainRoom"));
        }
        
    }

    private void ManageGame(){
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0)){
            playerPoints+=playerRate;
            Debug.Log("Current player points: " + playerPoints);
        }

        if (Time.time > nextActionTime ) {
            nextActionTime = Time.time + bossPeriod;
            bossPoints+=bossRate;
        }

        if (bossPoints >= objetive || playerPoints >= objetive)
            over = true;
    }

}
