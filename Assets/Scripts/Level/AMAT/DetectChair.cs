using UnityEngine;

public class DetectChair : MonoBehaviour
{
   public GameObject CanvasDialogue;

   public Sprite playerOnChair;
   void OnTriggerEnter2D(Collider2D collision){
       if (collision.gameObject.name == "Player"){
           GetComponent<SpriteRenderer>().sprite = playerOnChair;
           collision.gameObject.GetComponent<PlayerMobility>().frozen = true;
           collision.gameObject.GetComponent<PlayerSkills>().enabled = false;
           collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
           CanvasDialogue.SetActive(true);
           collision.gameObject.transform.position = gameObject.transform.position;
           gameObject.GetComponentInChildren<DialogueTrigger>().TriggerDialogue();
       }

   }
}
