using UnityEngine.SceneManagement;
using UnityEngine;

public class SkillTreeScript : MonoBehaviour
{
    public GameObject SkillTreeUI;
    public GameObject Player;
    private Vector3 PlayerPos; 
    
    public void Update(){
        if (SkillTreeUI.activeSelf){
            Player.transform.position = PlayerPos;
            if (Input.GetKey(KeyCode.Escape))
                CloseTree();
        }
    }

    public void ShowTree()
    {
        PlayerPos = Player.transform.position;
        SkillTreeUI.SetActive(true);
    }

    public void CloseTree()
    {
        SkillTreeUI.SetActive(false);
    }
}
