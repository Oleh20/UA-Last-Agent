using UnityEngine;

public class ChangeImage : MonoBehaviour
{
    [SerializeField] private Sprite startIcon;
    [SerializeField] private Sprite changeIcon;
    private SpriteRenderer image;
    private bool inColider = false;
    [SerializeField] private bool clicked = false;

    private void Start()
    {
        image = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            clicked = !clicked ? true : false;
            if (inColider && clicked)
            {
                image.sprite = changeIcon;
            }
            else if (inColider && !clicked)
            {
                image.sprite = startIcon;
            }


        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inColider = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inColider = false;
        }
    }
}
