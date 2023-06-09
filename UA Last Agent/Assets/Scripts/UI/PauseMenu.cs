using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool GameIsPaused = false;
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject buttonPause;
    [SerializeField] private Animator animator;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void Exit()
    {
        animator.SetTrigger("ResumeGame");
        Application.Quit();
    }

}
