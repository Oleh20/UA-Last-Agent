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
        
        if (NameOfRegion != null)
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
                    SetPositionPlayer();
                    PlayerPrefs.SetInt("PositionSeted", 1);
                }
            }
            else
            {
                SetPositionPlayer();
            }
            player.transform.position = position;
        }
    }
    private void OnApplicationQuit()
    {
        SavePositionData();

    }
    public void SavePositionPlayer(float x, float y)
    {
        PlayerPrefs.SetInt("SavedPlayerPositionX", Mathf.RoundToInt(x));
        PlayerPrefs.SetInt("SavedPlayerPositionY", Mathf.RoundToInt(y));
    }
    public void GetAndSavePositionPlayer()
    {

        PlayerPrefs.SetInt("SavedPlayerPositionX", Mathf.RoundToInt(player.transform.position.x));
        PlayerPrefs.SetInt("SavedPlayerPositionY", Mathf.RoundToInt(player.transform.position.y));
    }
    private void SetPositionPlayer()
    {
        position.x = PlayerPrefs.GetInt("SavedPlayerPositionX");
        position.y = PlayerPrefs.GetInt("SavedPlayerPositionY");
    }

    public void SavePositionData()
    {
        if (!PlayerPrefs.HasKey("MissionFinished"))
        {
            PlayerPrefs.SetInt("MissionFinished", 1);
            PlayerPrefs.SetInt("PositionSeted", 0);
            SavePositionPlayer(player.transform.position.x, player.transform.position.y);
        }
        else
        {
            if (PlayerPrefs.GetInt("MissionFinished", 0) == 1)
            {
                PlayerPrefs.SetInt("PositionSeted", 0);
                SavePositionPlayer(player.transform.position.x, player.transform.position.y);
            }
            else
            {
                PlayerPrefs.SetInt("MissionFinished", 1);
            }
        }
    }
   
}
