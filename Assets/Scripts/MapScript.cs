using UnityEngine;
using UnityEngine.SceneManagement;

public class MapScript : MonoBehaviour
{
    public GameObject MapUI;
    public GameObject Player;
    private Vector3 PlayerPos; 
    
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
