using UnityEngine;
using UnityEngine.SceneManagement;

public class MapScript : MonoBehaviour
{
    public GameObject MapUI;
    private Transform Player;
    private Vector3 PlayerPos; 

    void Start()
    {
        Player = GameObject.Find("Player").transform;
        //DontDestroyOnLoad(gameObject);
    }
    
    public void Update(){
        if (MapUI.activeSelf){
            Player.transform.position = PlayerPos;
            if (Input.GetKey(KeyCode.Escape))
                CloseMap();
        }
    }

    public void ShowMap()
    {
        PlayerPos = Player.transform.position;
        MapUI.SetActive(true);
    }

    public void CloseMap()
    {
        MapUI.SetActive(false);
    }

    public void AOCOLevel(){
        SceneManager.LoadScene("SampleScene");
    }
}
