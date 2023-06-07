using UnityEngine;


public class TopDownCharacterController : MonoBehaviour
{
    public float speed;

    private Animator animator;
    private PauseMenu pauseMenu;

    public int horizontal = 0;
    public int vertical = 0;

    private void Start()
    {
        pauseMenu = GameObject.FindObjectOfType<PauseMenu>();
        animator = GetComponent<Animator>();
        loadLastDirection();
    }


    private void Update()
    {
        if (pauseMenu.GameIsPaused == false)
        {
            Vector2 dir = Vector2.zero;
            if (Input.GetKey(KeyCode.A))
            {
                horizontal = -1;
                vertical = 0;
                dir.x = -1;
                animator.SetFloat("Horizontal", horizontal);
                animator.SetFloat("Vertical", vertical);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                horizontal = 1;
                vertical = 0;
                dir.x = 1;
                animator.SetFloat("Horizontal", horizontal);
                animator.SetFloat("Vertical", vertical);
            }

            if (Input.GetKey(KeyCode.W))
            {
                vertical = 1;
                horizontal = 0;
                dir.y = 1;
                animator.SetFloat("Horizontal", horizontal);
                animator.SetFloat("Vertical", vertical);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                vertical = -1;
                horizontal = 0;
                dir.y = -1;
                animator.SetFloat("Horizontal", horizontal);
                animator.SetFloat("Vertical", vertical);
            }


            dir.Normalize();
            animator.SetBool("IsMoving", dir.magnitude > 0);

            GetComponent<Rigidbody2D>().velocity = speed * dir;
        }
    }
    private void loadLastDirection()
    {
        float temp =  PlayerPrefs.GetFloat("Horizontal", 0);
        float temp2 =  PlayerPrefs.GetFloat("Vertical", 0);
        animator.SetFloat("Horizontal", PlayerPrefs.GetFloat("Horizontal",0));
        animator.SetFloat("Vertical",   PlayerPrefs.GetFloat("Vertical", 0));
    }   
}

