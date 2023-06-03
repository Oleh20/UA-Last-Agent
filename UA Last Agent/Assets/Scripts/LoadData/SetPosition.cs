using Unity.Mathematics;
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
 
    void Start()
    {
        if(NameOfRegion!= null)
        {
            NameOfRegion.SetActive(showNameOfRegion);
        }
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
            if (PlayerPrefs.GetInt("PositionSeted") == 0)
            {
                if (PlayerPrefs.HasKey("SavedPlayerPositionX") && PlayerPrefs.HasKey("SavedPlayerPositionY"))
                {
                    setPositionPlayer();
                    PlayerPrefs.SetInt("PositionSeted", 1);
                }
            }
            else
            {
                setPositionPlayer();
            }
            player.transform.position = position;
        }
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("PositionSeted", 0);
        savePositionPlayer(player.transform.position.x, player.transform.position.y);
    }
    public void savePositionPlayer(float x, float y)
    {
        PlayerPrefs.SetInt("SavedPlayerPositionX", Mathf.RoundToInt(x));
        PlayerPrefs.SetInt("SavedPlayerPositionY", Mathf.RoundToInt(y));
    }
    private void setPositionPlayer()
    {
        position.x = PlayerPrefs.GetInt("SavedPlayerPositionX");
        position.y = PlayerPrefs.GetInt("SavedPlayerPositionY");
    }
}
