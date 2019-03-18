using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Clickable : MonoBehaviour
{
    private Torcato torcato;
    public abstract bool check { get; }

    // Start is called before the first frame update
    void Start()
    {
        torcato = GameObject.Find("Torcato").GetComponent<Torcato>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        torcato.CheckAnswer(check);
    }
}
