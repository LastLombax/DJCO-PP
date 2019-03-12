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
    private bool state;
    private bool over;
    
    // Start is called before the first frame update
    void Start()
    {
        level = 0;
        state = true;
        over = false;
        world = GameObject.Find("world");
        sentences = GameObject.Find("rules");
    }

    // Update is called once per frame
    void Update()
    {
        if (level >= answers.Length) {
            over = true;
        }

        if (over) {
            if (state) {
                Debug.Log("Passaste");
            } else {
                Debug.Log("Lamento, mas não obtiveste uma classificação satisfatória...");
            }
            StartCoroutine(gm.Load2Scene("MainRoom"));
        }
    }

    public void CheckAnswer(bool answer) 
    {
        Debug.Log(level);
        state = state && (answer == answers[level]);
        level++;
        if (level < answers.Length){
            world.GetComponent<SpriteRenderer>().sprite = worlds[level];
            sentences.GetComponent<SpriteRenderer>().sprite = rules[level];
        }
    }
}
