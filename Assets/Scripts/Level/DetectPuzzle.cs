using UnityEngine;

public class DetectPuzzle : MonoBehaviour
{
    public GameObject CanvasDialogue;

    public DialogueManager dm;

    private bool ended;
    private bool alreadyDoneDialog = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(alreadyDoneDialog)
        {
            return;
        }
        if (collision.gameObject.name == "Player")
        {
            dm.Start();
            ended = false;
            collision.gameObject.GetComponent<PlayerMobility>().frozen = true;
            CanvasDialogue.SetActive(true);
            gameObject.GetComponentInChildren<DialogueTrigger>().TriggerDialogue();
            alreadyDoneDialog = true;
        }
    }

    void Update()
    {
        if (!ended)
            if (dm.dialogueEnd)
            {
                GameObject.Find("Player").GetComponent<PlayerMobility>().frozen = false;
                CanvasDialogue.SetActive(false);
                ended = true;
            }
    }
}
