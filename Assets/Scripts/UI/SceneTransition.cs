using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }


    public void GoingToNextScene()
    {
        SceneManager.LoadScene(0);
    }
}