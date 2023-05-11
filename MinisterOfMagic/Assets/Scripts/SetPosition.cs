using UnityEngine;

public class SetPosition : MonoBehaviour
{
    [SerializeField] private bool setPositon;
    [SerializeField] private int sortLevel;
    [SerializeField] private int directionPlayer;
    [SerializeField] private GameObject fadeIn;
    [SerializeField] private GameObject NameOfRegion;
    [SerializeField] private bool showNameOfRegion;
    private GameObject player;
    private PlayerController playerContoreller;
    private Animator playerAnimator;
    private Renderer playerSprite;
    [SerializeField] private Vector3 position;
    void Start()
    {
        NameOfRegion.SetActive(showNameOfRegion);
        player = GameObject.Find("Player");
        playerContoreller = player.GetComponent<PlayerController>();
        playerAnimator = player.GetComponent<Animator>();
        playerSprite = player.GetComponent<Renderer>();
    }
    public void SetDataAfterChangeScene()
    {
        playerSprite.sortingOrder = sortLevel;
        playerAnimator.SetInteger("Direction", directionPlayer);
        playerContoreller.transitionObjectScene = fadeIn;
        if (player != null && setPositon)
        {
            player.transform.position = position;
        }
    }
}
