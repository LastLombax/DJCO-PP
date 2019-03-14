using UnityEngine;

public class DetectDonaLina : MonoBehaviour
{
   public GameObject CanvasDialogue;

   public DialogueManager dm;

   private bool ended;

   void OnTriggerEnter2D(Collider2D collision){
       if (collision.gameObject.name == "Player"){
           ended = false;
           collision.gameObject.GetComponent<PlayerMobility>().frozen = true;
           CanvasDialogue.SetActive(true);
           gameObject.GetComponentInChildren<DialogueTrigger>().TriggerDialogue();
       }
   }

   void Update(){
        if (!ended)
            if (dm.dialogueEnd){
                GameObject.Find("Player").GetComponent<PlayerCollision>().skillTree.GetComponent<SkillTreeScript>().ShowTree();
            ended = true;
        }
   }
}
