using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool isApplicationQuitting = false;
    private static GameObject gameManager;

    private void Awake()
    {
        gameManager = gameObject;
        checkOnLoadScene();
    }

    private void Start()
    {
        DontDestroyOnLoad(gameManager);
    }

    private void OnDisable()
    {
        SaveScene();
    }

    private void SaveScene()
    {
        string currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString("LastScene", currentScene);
    }

    private void LoadLastScene()
    {
        if (PlayerPrefs.HasKey("LastScene"))
        {
            string lastScene = PlayerPrefs.GetString("LastScene");
            UnityEngine.SceneManagement.SceneManager.LoadScene(lastScene);
        }
    }

    private void OnApplicationQuit()
    {
        isApplicationQuitting = true;
    }

    private void OnApplicationFocus(bool hasFocus)
    {
        if (!hasFocus && !isApplicationQuitting)
        {
            PlayerPrefs.SetInt("LoadFirstTime", 1);
        }
    }

    private void checkOnLoadScene()
    {
        if (PlayerPrefs.HasKey("LoadFirstTime"))
        {
            if (PlayerPrefs.GetInt("LoadFirstTime", 0) == 1)
            {
                LoadLastScene();
                PlayerPrefs.SetInt("LoadFirstTime", 0);
            }
        }
        else
        {
            LoadLastScene();
            PlayerPrefs.SetInt("LoadFirstTime", 0);
        }
    }
}