using UnityEngine;

public class SetPosition : MonoBehaviour
{
    [SerializeField] private bool setPositon;
    [SerializeField] private int sortLevel;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject fadeIn;
    private PlayerController playerContoreller;
    private Renderer playerSprite;
    [SerializeField] private Vector3 position;
    void Start()
    {
        player = GameObject.Find("Player");
        playerContoreller = player.GetComponent<PlayerController>();
        playerSprite = player.GetComponent<Renderer>();
    }
    public void SetDataAfterChangeScene()
    {
        playerSprite.sortingOrder = sortLevel;
        playerContoreller.transitionObjectScene = fadeIn;
        if (player != null && setPositon)
        {
            player.transform.position = position;
        }
    }
}
