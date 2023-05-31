using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_menu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject buttonPause;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        buttonPause.SetActive(true);
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        buttonPause.SetActive(false);
    }

    public void LoadMenu()
    {
        Debug.Log("Menu");
    }

    public void Exit()
    {
        Debug.Log("Exit");
    }

}
