using UnityEngine;

public class DetectChair : MonoBehaviour
{
   public GameObject CanvasDialogue;
   void OnTriggerEnter2D(Collider2D collision){
       if (collision.gameObject.name == "Player"){
           CanvasDialogue.SetActive(true);
           GetComponent<MeshRenderer>().enabled= false;
           collision.gameObject.transform.position = gameObject.transform.position;
           gameObject.GetComponentInChildren<DialogueTrigger>().TriggerDialogue();
       }

   }
}
