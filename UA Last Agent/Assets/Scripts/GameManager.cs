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

        loadLastScene();
    }

    private void OnApplicationQuit()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        lastSceneName = currentScene.name;
        File.WriteAllText(saveFileName, lastSceneName);
    }
    private void loadLastScene()
    {
        gameManager = gameObject;
        DontDestroyOnLoad(gameManager);
        if (!string.IsNullOrEmpty(lastSceneName))
        {
            SceneManager.LoadScene(lastSceneName);
        }
        if (File.Exists(saveFileName))
        {
            lastSceneName = File.ReadAllText(saveFileName);
            SceneManager.LoadScene(lastSceneName);
        }
        else
        {
            File.WriteAllText(saveFileName, string.Empty);
        }
    }

}