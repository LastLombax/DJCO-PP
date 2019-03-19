using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float loadDelay = 3f;
    // Start is called before the first frame update

    public static GameManager gm;


    void Start()
    {
         if(gm){
            Destroy(gameObject);
        }else
        {
            DontDestroyOnLoad(gameObject);
            gm = this;
        }
    }
    public IEnumerator Load2Scene(string SceneName){
        yield return new WaitForSeconds(loadDelay);
        SceneManager.LoadScene(SceneName);  
        yield return null;
    }

    void OnEnable()
    {
    //Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
    //Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        var player = GameObject.Find("Player");
        if (scene.name == "MainRoom"){
            player.GetComponent<AudioSource>().Stop();
            player.transform.position = new Vector3(-8f, 290f, 0);
            player.gameObject.GetComponent<PlayerMobility>().frozen = false;
            player.gameObject.GetComponent<PlayerSkills>().enabled = true;
            player.gameObject.GetComponent<SpriteRenderer>().enabled = true;

            player.GetComponent<PlayerCollision>().map = GameObject.Find("Map");
            player.GetComponent<PlayerCollision>().skillTree = GameObject.Find("SkillTreeFireBall");
            player.GetComponent<PlayerCollision>().FEUPLetters = GameObject.Find("FEUPLetters");
            player.GetComponent<PlayerCollision>().FEUPLetters.GetComponent<Animator>().enabled = false;
        } else if (scene.name == "StartMenu") {
            player.GetComponent<AudioSource>().Stop();
        } else {
            player.GetComponent<AudioSource>().time = 1f;
            player.GetComponent<AudioSource>().Play();
        }

    }
}
