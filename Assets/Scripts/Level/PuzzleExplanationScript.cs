using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleExplanationScript : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject player;
    public GameObject text;
    void Start()
    {
        player = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.GetComponent<FloorScript>().isPlayerHere)
            text.SetActive(true);
        else
            text.SetActive(false);

    }
}
