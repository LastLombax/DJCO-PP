using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButtons : MonoBehaviour
{
    public GameObject Buttons;

    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name, LoadSceneMode.Single);
    }
}
