using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelTransition : MonoBehaviour
{

    [SerializeField] private int numberOfScene;
    
    public void changeScene()
    {
        SceneManager.LoadScene(numberOfScene);
    }
}
