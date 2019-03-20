using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torcato : MonoBehaviour
{
    public GameManager gm;

    public Sprite[] worlds;
    public Sprite[] rules;

    private GameObject world;
    private GameObject sentences;

    private bool[] answers = {true, true, false, false, true};
    private int level;
    private int score;
    private bool over;
    private bool done;
    
    // Start is called before the first frame update
    void Start()
    {
        level = 0;
        score = 0;
        over = false;
        done = false;
        world = GameObject.Find("world");
        sentences = GameObject.Find("rules");
    }

    // Update is called once per frame
    void Update()
    {
        if (level >= answers.Length) {
            over = true;
        }

        if (over && !done) {
            done = true;
            if (score >= 3) {
                Debug.Log("Passaste");
            } else {
                Debug.Log("Lamento, mas não obtiveste uma classificação satisfatória...");
            }
            GameObject.Find("Player").GetComponent<PlayerStats>().CompleteUC("MDIS");
            StartCoroutine(gm.Load2Scene("MainRoom"));
        }
    }

    public void CheckAnswer(bool answer) 
    {
        score += answer == answers[level] ? 1 : 0;
        level++;
        if (level < answers.Length){
            world.GetComponent<SpriteRenderer>().sprite = worlds[level];
            sentences.GetComponent<SpriteRenderer>().sprite = rules[level];
        }
    }
}
