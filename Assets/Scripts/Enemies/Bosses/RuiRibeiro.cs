using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RuiRibeiro : MonoBehaviour
{
    public float objetive = 100;
    public float bossRate = 10;
    public float playerRate = 5;
    public float bossPeriod = 1;
    private float playerPoints = 0;
    private float bossPoints = 0;
    private float nextActionTime = 0;
    private float nextCoolDownTime = 0;
    private int phase = 0;

    public Text playerScore;
    public Text bossScore;
    public Text CountdownUI;

    public GameObject Canvas_BossBattle;
    public DialogueManager dm;
    public GameManager gm;
    private bool over = false;
    private bool done = false;
    private int countdown = 4;

    void Update(){
        if (dm.dialogueEnd){
            if (!Canvas_BossBattle.activeSelf)
                Canvas_BossBattle.SetActive(true);
            if(countdown == 0){
                CountdownUI.gameObject.SetActive(false);
                if (!over){
                    ManageGame();
                }
                else if (!done){
                    done = true;
                    if (bossPoints >= objetive) {
                        gm.BossResult("Lost");
                        Debug.Log("Era so fazer as continhas... tás chumbado");
                    } else if (playerPoints >= objetive) {
                        Debug.Log("Passaste");                        
                        gm.BossResult("Won");
                        GameObject.Find("Player").GetComponent<PlayerStats>().CompleteUC("AMAT");
                    }
                    GameObject.Find("door8").GetComponent<AudioSource>().Stop();
                    StartCoroutine(gm.Load2Scene("MainRoom"));
                }
            }
            else if (Time.time > nextCoolDownTime ) {
                nextCoolDownTime = Time.time + 1;
                countdown--;
                CountdownUI.text = "Round " + (phase + 1) + ": " + countdown.ToString("0");
            }
        }
    }

    private void ManageGame(){

        playerScore.text = playerPoints.ToString("0");
        bossScore.text = bossPoints.ToString("0");

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
            playerPoints+=playerRate;


        if (Time.time > nextActionTime ) {
            nextActionTime = Time.time + bossPeriod;
            bossPoints+=bossRate;
        }

        if (bossPoints >= objetive)
            over= true;

        switch(phase){
            case 0:
                if (playerPoints >= objetive)
                   ChangePhase(0.5f);                
                break;                
            case 1:
               if (playerPoints >= objetive)
                    ChangePhase(0.25f);
                break;
            case 2:
                if (playerPoints >= objetive)
                    over = true;
                break;
        }        
    }

    private void ChangePhase(float newBossPeriod){
        phase++;
        bossPeriod = newBossPeriod;
        playerPoints = 0;
        bossPoints = 0;
        countdown = 4;
        CountdownUI.gameObject.SetActive(true);
    }

}
