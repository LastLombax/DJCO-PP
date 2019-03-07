using UnityEngine;

public class DetectChair : MonoBehaviour
{
   public GameObject CanvasDialogue;
   void OnTriggerEnter2D(Collider2D collision){
       if (collision.gameObject.name == "Player"){
           Destroy(collision.gameObject.GetComponent<PlayerMobility>());
           Destroy(collision.gameObject.GetComponent<PlayerSkills>());
           CanvasDialogue.SetActive(true);
           GetComponent<MeshRenderer>().enabled= false;
           collision.gameObject.transform.position = gameObject.transform.position;
           gameObject.GetComponentInChildren<DialogueTrigger>().TriggerDialogue();
       }

   }
}
