using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject buttonPause;
    public Animator animator;


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
        animator.SetTrigger("ResumeGame");
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
        animator.SetTrigger("ResumeGame");
        Debug.Log("Menu");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void Exit()
    {
        animator.SetTrigger("ResumeGame");
        Debug.Log("Exit");
        Application.Quit();
    }

}
