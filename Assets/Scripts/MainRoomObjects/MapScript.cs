using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
        foreach(string uc in Player.GetComponent<PlayerStats>().ucsCompleted) {
            MapUI.transform.Find(uc).gameObject.GetComponent<Image>().color = Color.green;
        }

    }

    public void CloseMap()
    {
        MapUI.SetActive(false);
    }
    public void testF(int a, int b)
    {
        return;
    }

    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name, LoadSceneMode.Single);
    }

}
