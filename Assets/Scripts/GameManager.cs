using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float loadDelay = 3f;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public IEnumerator Load2Scene(string SceneName){
        yield return new WaitForSeconds(loadDelay);
        SceneManager.LoadScene(SceneName);  
        yield return null;
    }
}
