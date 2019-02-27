using UnityEngine.SceneManagement;
using UnityEngine;

public class SkillTreeScript : MonoBehaviour
{
    public GameObject SkillTreeUI;
    private Transform Player;
    private Vector3 PlayerPos; 

    void Start()
    {
        Player = GameObject.Find("Player").transform;
        //DontDestroyOnLoad(gameObject);
    }
    
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
