using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private string lastSceneName;
    private string saveFileName = "lastscene.txt";
    private static GameObject gameManager;

    private void Awake()
    {
        LoadLastScene();
    }

    private void OnEnable()
    {
        LoadLastScene();
    }

    private void OnApplicationQuit()
    {
        SaveLastScene();
    }

    private void SaveLastScene()
    {
      
        Scene currentScene = SceneManager.GetActiveScene();
        lastSceneName = currentScene.name;
        File.WriteAllText(saveFileName, lastSceneName);
    }

    private void LoadLastScene()
    {
        gameManager = gameObject;
        DontDestroyOnLoad(gameManager);

        if (File.Exists(saveFileName))
        {
            lastSceneName = File.ReadAllText(saveFileName);
            SceneManager.LoadScene(lastSceneName);
        }
    }

    private void OnDestroy()
    {
        SaveLastScene();
    }
}
