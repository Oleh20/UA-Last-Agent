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
    public Vector3 position;
    private void Awake()
    {
      
    }
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
            if (!PlayerPrefs.HasKey("PositionSeted"))
            {
                PlayerPrefs.SetInt("PositionSeted", 0);
            }
            if(PlayerPrefs.GetInt("PositionSeted") == 0)
            {
                if (PlayerPrefs.HasKey("SavedPlayerPositionX") && PlayerPrefs.HasKey("SavedPlayerPositionY"))
                {
                    position.x = PlayerPrefs.GetInt("SavedPlayerPositionX");
                    position.y = PlayerPrefs.GetInt("SavedPlayerPositionY");
                    PlayerPrefs.SetInt("PositionSeted", 1);
                }
            }
            player.transform.position = position;
        }
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("PositionSeted", 0);
        PlayerPrefs.SetInt("SavedPlayerPositionX", Mathf.RoundToInt(player.transform.position.x));
        PlayerPrefs.SetInt("SavedPlayerPositionY", Mathf.RoundToInt(player.transform.position.y));
    }
}
